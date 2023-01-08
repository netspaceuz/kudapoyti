using AutoMapper;
using kudapoyti.DataAccess.DbConstexts;
using kudapoyti.DataAccess.Interfaces;
using kudapoyti.Service.Dtos.Places;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.ViewModels;
using kudapoyti.Domain.Entities.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;

        public PlaceService(IUnitOfWork unitOfWork, IMapper mapper, AppDbContext appDbContext)
        {
            this._repository = unitOfWork;
            this._mapper = mapper;
            this._appDbContext = appDbContext;
        }
        public async Task<bool> CreateAsync(PlaceCreateDto dto)
        {
            var entity = (Place)dto;
            _appDbContext.Places.Add(entity);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Place>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PlaceViewModel> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(long id, PlaceCreateDto updateDto)
        {
            throw new NotImplementedException();
        }

    }
}
