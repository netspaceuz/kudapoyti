using AutoMapper;
using kudapoyti.DataAccess.DbConstexts;
using kudapoyti.DataAccess.Interfaces;
using kudapoyti.Domain.Entities.Comment;
using kudapoyti.Domain.Entities.Places;
using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Common.Helpers;
using kudapoyti.Service.Common.Utils;
using kudapoyti.Service.Dtos;
using kudapoyti.Service.Dtos.CommentDtos;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.Interfaces.CommentServices;
using kudapoyti.Service.Interfaces.Common;
using kudapoyti.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly IPaginationService _paginator;
        private readonly IUnitOfWork _repository;

        public CommentService(IUnitOfWork unitOfWork, IPaginationService paginatorService)
        {
            this._paginator = paginatorService;
            this._repository = unitOfWork;
        }

        public async Task<bool> CreateAsync(CommentCreateDto createDto)
        {
            var entity = (Comment)createDto;
            _repository.Comments.CreateAsync(entity);
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _repository.Comments.FindByIdAsync(id);
            if (entity is not null)
            {
                _repository.Comments.DeleteAsync(id);
                var result = await _repository.SaveChangesAsync();
                return result > 0;
            }
            else throw new StatusCodeException(HttpStatusCode.NotFound, "Comment is not found.");
        }
        public async Task<IEnumerable<CommentsViewModel>> GetByPlaceId(long id, PaginationParams @paginationParams)
        {
            var query = _repository.Comments.GetAll().Where(x=>x.PlaceId == id).Select(x => (CommentsViewModel)x);
            var data = await _paginator.ToPagedAsync(query, @paginationParams.PageNumber, @paginationParams.PageSize);
            return data;
        }
    }
}
