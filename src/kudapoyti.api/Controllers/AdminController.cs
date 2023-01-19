using kudapoyti.Domain.Constants;
using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Common.Utils;
using kudapoyti.Service.Dtos;
using kudapoyti.Service.Dtos.Accounts;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.Interfaces.Common;
using kudapoyti.Service.Services.KudaPaytiService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace kudapoyti.api.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _admin;
        private readonly IPaginationService _pager;
        private readonly int _pageSize = PageSize.PAGESIZE;
        private readonly IAuthenticationAttribute _auth;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminController(IAdminService admin, IPaginationService paginationService, IHttpContextAccessor contextAccessor, IAuthenticationAttribute auth)
        {
            _admin = admin;
            _pager = paginationService;
            _auth = auth;
            _httpContextAccessor= contextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int page)
        {
                List<string> rols = new List<string>() { "SuperAdmin", "Admin" };
                if (_auth.IsAuthed(rols, _httpContextAccessor.HttpContext))
                {
                    return Ok(await _admin.GetAllAysnc(new PaginationParams(page, _pageSize)));
                }
                else
                    throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "You haven't access");
            
        }

        [HttpPost("RegistrAdmin")]
        public async Task<IActionResult> RegisterAsync([FromForm] AdminCreateDto registerDto)
        {
            List<string> rols = new List<string>() { "SuperAdmin"};
            if (_auth.IsAuthed(rols, _httpContextAccessor.HttpContext))
            {
                return Ok(await _admin.RegisterAsync(registerDto));
            }
            else
                throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "You haven't access");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            List<string> rols = new List<string>() { "SuperAdmin","Admin" };
            if (_auth.IsAuthed(rols, _httpContextAccessor.HttpContext))
            {
                return Ok(await _admin.GetAysnc(id));
            }
            else
                throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "You haven't access");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            List<string> rols = new List<string>() { "SuperAdmin" };
            if (_auth.IsAuthed(rols, _httpContextAccessor.HttpContext))
            {
                return Ok(await _admin.DeleteAysnc(id));
            }
            else
                throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "You haven't access");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] UpdateCreateDto dto)
        {
            List<string> rols = new List<string>() { "SuperAdmin" };
            if (_auth.IsAuthed(rols, _httpContextAccessor.HttpContext))
            {
                return Ok(await _admin.UpdateAysnc(id, dto));
            }
            else
                throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "You haven't access");
        }
    }
}
