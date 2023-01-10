using kudapoyti.Domain.Constants;
using kudapoyti.Service.Common.Utils;
using kudapoyti.Service.Dtos;
using kudapoyti.Service.Dtos.Accounts;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.Interfaces.Common;
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
        public AdminController(IAdminService admin, IPaginationService paginationService)
        {
            _admin = admin;
            _pager = paginationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int page)
            => Ok(await _admin.GetAllAysnc(new PaginationParams(page, _pageSize)));

        [HttpPost("RegistrAdmin")]
        public async Task<IActionResult> RegisterAsync([FromForm] AdminCreateDto registerDto)
            => Ok(await _admin.RegisterAsync(registerDto));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
            =>Ok(await _admin.GetAysnc(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
            =>Ok(await _admin.DeleteAysnc(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] UpdateCreateDto dto)
            => Ok(await _admin.UpdateAysnc(id, dto));
    }
}
