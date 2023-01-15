﻿using kudapoyti.Service.Common.Attributes;
using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Dtos.AccountDTOs;
using kudapoyti.Service.Helpers;
using kudapoyti.Service.Interfaces.CommentServices;
using kudapoyti.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;


namespace kudapoyti.api.Controllers
{
    [ApiController]
    [Route("api/validuser")]
    public class ValidUserController: ControllerBase
    {
        private readonly IUserService _userService;

        public ValidUserController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromForm] UserValidateDto validateDto)
        {
            try
            {
                await _userService.LoginAsync(validateDto);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("verify"), AllowAnonymous]
        public async Task<IActionResult> VerifyCodeAsync(string email, [RegularExpression(@"^\d{6}$",
            ErrorMessage = "Code must be 6 digits")] string code)
        {
            try
            {
                var result = await _userService.VerifyCodeAsync(email,code);
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
