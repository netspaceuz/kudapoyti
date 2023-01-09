using kudapoyti.Service.Dtos.Accounts;
using kudapoyti.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kudapoyti.api.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class AdminAccountController : ControllerBase
    {
        private readonly IAdminAccountService _admin;
        public AdminAccountController(IAdminAccountService admin)
        {
            _admin=admin;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromForm] AdminAccountLoginDto loginDto)
            => Ok(await _admin.LoginAsync(loginDto));

    }
}
