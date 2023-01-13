using kudapoyti.Domain.Constants;
using kudapoyti.Domain.Enums;
using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Common.Helpers;
using kudapoyti.Service.Common.Utils;
using kudapoyti.Service.Dtos.CommentDtos;
using kudapoyti.Service.Interfaces.CommentServices;
using kudapoyti.Service.Interfaces.Common;
using kudapoyti.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations;

namespace kudapoyti.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentservice;
        private readonly IPaginationService _pager;
        private readonly int _pageSize = PageSize.PAGESIZE;

        public CommentController(ICommentService commentService)
        {
            _commentservice = commentService;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] CommentCreateDto dto)
        {
            try
            {
                var authHeader = HttpContext.Request.Headers["Authorization"];
                CurrenUser.Token = authHeader.ToString().Substring("Bearer ".Length).Trim();
                if (!string.IsNullOrEmpty(CurrenUser.Token))
                {
                    await _commentservice.CreateAsync(dto);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw new StatusCodeException(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByPlaceId([RegularExpression("^[0-9]+$", ErrorMessage = "Id must be a number")] long id, [RegularExpression("^[0-9]+$", ErrorMessage = "Pagenumber must be a digit")] int page)
            => Ok(await _commentservice.GetByPlaceId(id, new PaginationParams(page, _pageSize)));
        [HttpDelete]
        public async Task<IActionResult> DeleteById([RegularExpression("^[0-9]+$", ErrorMessage = "Id must be a number")] long id)
            => Ok(await _commentservice.DeleteAsync(id));
    }
}
