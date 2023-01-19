using kudapoyti.Service.Common.Utils;
using kudapoyti.Service.Dtos;
using kudapoyti.Service.Dtos.CommentDtos;
using kudapoyti.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Interfaces.CommentServices
{
    public interface ICommentService
    {
        public Task<bool> CreateAsync(CommentCreateDto createDto);
        public Task<IEnumerable<CommentsViewModel>> GetByPlaceId(long id, PaginationParams @paginationParams);
        public Task<bool> DeleteAsync(long id);
    }
}
