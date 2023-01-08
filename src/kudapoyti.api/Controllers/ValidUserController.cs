using kudapoyti.Service.Dtos.AccountDTOs;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kudapoyti.api.Controllers
{
    [Route("api/validuser")]
    [ApiController]
    public class ValidUserController : ControllerBase
    {
        private readonly IUserService _userService;

        public ValidUserController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromForm] UserValidateDto validateDto)
            => Ok(new { Token = await _userService.LoginAsync(validateDto)});
    }
}
