using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Dtos.AccountDTOs;
using kudapoyti.Service.Interfaces.CommentServices;
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
        {
            try
            {
                await _userService.LoginAsync(validateDto);
                return Ok(validateDto);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost("varify")]
        public async Task<IActionResult> VerifyCodeAsync([FromForm] string code)
        {
            try
            {
                var result = await _userService.VerifyCodeAsync(code);
                if (result.Item1 == true)
                {
                    return Ok($"{result.Item2}");
                }
                else
                    return BadRequest("Wrong code entered");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
