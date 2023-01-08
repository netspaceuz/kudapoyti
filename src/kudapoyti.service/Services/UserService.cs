using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Common.Security;
using kudapoyti.Service.Dtos.AccountDTOs;
using kudapoyti.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Services
{
    public class UserService:IUserService
    {
        private readonly IAuthManager _authManager;

        public UserService(IAuthManager authManager) 
        {
            _authManager = authManager;
        }
        public async Task<string> LoginAsync(UserValidateDto userValidate)
        {
            try
            {
                return _authManager.GenerateToken(userValidate);
            }
            catch
            {
                throw new StatusCodeExeption(HttpStatusCode.BadRequest, "Something went wrong");
            }
        }
    }
}
