using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Common.Security;
using kudapoyti.Service.Dtos.AccountDTOs;
using kudapoyti.Service.Interfaces.CommentServices;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Services.CommentServices
{
    public class UserService : IUserService
    {
        private readonly IEmailService _emailService;
        private readonly ICacheService cacheService;
        private readonly IAuthManager _authManager;

        public UserService(IEmailService emailService, ICacheService cacheService,IAuthManager authManager)
        {
            _emailService = emailService;
            this.cacheService = cacheService;
            _authManager = authManager;
        }
        public async Task LoginAsync(UserValidateDto userValidate)
        {
            try
            {
                await _emailService.SendAsync(userValidate);
            }
            catch
            {
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Something went wrong");
            }
        }
        public async Task<(bool,string)> VerifyCodeAsync(string email,string code)
        {
            try
            {
                var realCode = await cacheService.GetValueAsync(email);
                if (realCode.Item1 != null)
                {
                    if (realCode.Item1 == code)
                        return (true, _authManager.GenerateToken(realCode.Item2));
                    else if (realCode.Item2 == null)
                        throw new StatusCodeException(HttpStatusCode.Gone, "Code time limit expired");
                    else
                        throw new StatusCodeException(HttpStatusCode.Forbidden, "Verification code is wrong");
                }
                throw new Exception("There aren't any request of login");
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}
