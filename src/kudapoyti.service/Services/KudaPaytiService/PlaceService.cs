using AutoMapper;
using kudapoyti.DataAccess.DbConstexts;
using kudapoyti.DataAccess.Interfaces;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.ViewModels;
using kudapoyti.Domain.Entities.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using kudapoyti.Service.Common.Helpers;
using kudapoyti.Service.Common.Exceptions;
using System.Net;
using kudapoyti.Service.Dtos;
using kudapoyti.Service.Interfaces.Common;
using kudapoyti.Service.Common.Utils;
using kudapoyti.Service.Services.Common;
using kudapoyti.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace kudapoyti.Service.Services.KudaPaytiService
{
    public class PlaceService : IPlaceService
    {
        private readonly IPaginationService _paginator;
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        private readonly IImageService _imageService;

        public PlaceService(IUnitOfWork unitOfWork,IMapper mapper,  AppDbContext appDbContext, IImageService imageService, IPaginationService paginatorService)
        {
            this._paginator = paginatorService;
            this._repository = unitOfWork;
            this._mapper = mapper;
            this._appDbContext = appDbContext;
            this._imageService = imageService;
        }
        public async Task<bool> CreateAsync(PlaceCreateDto dto)
        {
            var entity =_mapper.Map<Place>(dto);
            entity.rank = 0;
            entity.rankedUsersCount = 0;
            entity.Ranked_point = 0;
            entity.ImageUrl = await _imageService.SaveImageAsync(dto.Image!);
            entity.CreatedAt = TimeHelper.GetCurrentServerTime();
            //_appDbContext.Places.Add(entity);
            _repository.Places.CreateAsync(entity);
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _repository.Places.FindByIdAsync(id);
            if (entity is not null)
            {
                _repository.Places.DeleteAsync(id);
                var result = await _repository.SaveChangesAsync();
                return result > 0;
            }
            else throw new StatusCodeException(HttpStatusCode.NotFound, "Car is not found.");
        }

        public async Task<IEnumerable<Place>> GetAllAsync(PaginationParams @paginationParams)
        {
            var query = _repository.Places.GetAll().OrderBy(x=>x.rank);
            var data = await _paginator.ToPagedAsync(query, @paginationParams.PageNumber, @paginationParams.PageSize);
            return data;
        }

        public async Task<PlaceViewModel> GetAsync(long id)
        {
            var mapper = new Mapper(new MapperConfiguration
                (cfg => cfg.CreateMap<Place, PlaceViewModel>().ReverseMap()));
            var place = await _appDbContext.Places.FindAsync(id);
            if (place is not null)
            {
                var res = mapper.Map<PlaceViewModel>(place);
                return res;
                
            }
            else throw new StatusCodeException(HttpStatusCode.NotFound, "Place is not found");
        }
        public async Task<IEnumerable<PlaceViewModel>> GetByKeyword(string keyword)
        {
            IEnumerable<PlaceViewModel> places = await _appDbContext.Places
                .Where(x=>x.Title.ToLower().Contains(keyword.ToLower())
                || x.Description.ToLower().Contains(keyword.ToLower())
                || x.Region.ToLower().Contains(keyword.ToLower()))
                .Select(x => _mapper.Map<PlaceViewModel>(x)).ToListAsync();
            return places;
        }
        public async Task<bool> UpdateAsync(long id, PlaceCreateDto updateDto)
        {
            var place = await _repository.Places.FindByIdAsync(id);
            if (place is null) throw new StatusCodeException(HttpStatusCode.NotFound, "Place is not found");

            var updatePlace = _mapper.Map<Domain.Entities.Places.Place>(updateDto);

            if (updateDto.Image is not null)
            {
                await _imageService.DeleteImageAsync(place.ImageUrl!);
                updatePlace.ImageUrl = await _imageService.SaveImageAsync(updateDto.Image);
            }
            updatePlace.Id = id;

            _repository.Places.UpdateAsync(id, updatePlace);
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }

        public Task<bool> UpdateAsync(long id, PlaceUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }

        Task<PlaceViewModel> IPlaceService.GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
