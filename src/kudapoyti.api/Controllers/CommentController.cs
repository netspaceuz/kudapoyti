using kudapoyti.Domain.Constants;
using kudapoyti.Domain.Enums;
using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Common.Helpers;
using kudapoyti.Service.Common.Utils;
using kudapoyti.Service.Dtos.CommentDtos;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.Interfaces.CommentServices;
using kudapoyti.Service.Interfaces.Common;
using kudapoyti.Service.Services.KudaPaytiService;
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
        private readonly IAuthenticationAttribute _auth;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentController(ICommentService commentService, IAuthenticationAttribute auth, IHttpContextAccessor contextAccessor)
        {
            _commentservice = commentService;
            _auth = auth;
            _httpContextAccessor = contextAccessor;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CommentCreateDto dto)
        {
            List<string> rols = new List<string>() { "User", "Admin","SuperAdmin" };
            if (_auth.IsAuthed(rols, _httpContextAccessor.HttpContext))
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
            else
                throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "You haven't access");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByPlaceId([RegularExpression("^[0-9]+$", ErrorMessage = "Id must be a number")] long id, [RegularExpression("^[0-9]+$", ErrorMessage = "Pagenumber must be a digit")] int page)
            => Ok(await _commentservice.GetByPlaceId(id, new PaginationParams(page, _pageSize)));
        [HttpDelete]
        public async Task<IActionResult> DeleteById([RegularExpression("^[0-9]+$", ErrorMessage = "Id must be a number")] long id)
        {
            List<string> rols = new List<string>() { "SuperAdmin","Admin" };
            if (_auth.IsAuthed(rols, _httpContextAccessor.HttpContext))
            {
                return Ok(await _commentservice.DeleteAsync(id));
            }
            else
                throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "You haven't access");
        }
    }
}
