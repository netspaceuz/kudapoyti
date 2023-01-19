using kudapoyti.Domain.Entities.Comment;
using kudapoyti.Domain.Entities.Places;
using kudapoyti.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.ViewModels
{
    public class CommentsViewModel
    {
        public string Comments { get; set; } = String.Empty;

        public string UserName { get; set; } = String.Empty;

        public static implicit operator CommentsViewModel(Comment comment)
        {
            return new()
            {
                Comments = comment.Comments,
                UserName = comment.UserName
            };
        }
    }
}
