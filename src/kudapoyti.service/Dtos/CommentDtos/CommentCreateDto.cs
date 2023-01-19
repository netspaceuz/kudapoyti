using kudapoyti.Domain.Entities.Comment;
using kudapoyti.Domain.Entities.Places;
using kudapoyti.Service.Common.Constants;
using kudapoyti.Service.Common.Helpers;
using kudapoyti.Service.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Dtos.CommentDtos
{
    public class CommentCreateDto
    {
        [Required]
        public string Comments { get; set; }
        [Required]
        public int PlaceId { get; set; }
        public static implicit operator Comment(CommentCreateDto dto)
        {
            return new Comment()
            {
                Comments = dto.Comments,
                PlaceId = dto.PlaceId,
                CreatedAt = TimeHelper.GetCurrentServerTime(),
                UserEmail = TokenService.GetValue(CurrenUser.Token, "emailaddress"),
                UserName = TokenService.GetValue(CurrenUser.Token, "name")
            };
        }
    }

}
