using kudapoyti.DataAccess.Interfaces;
using kudapoyti.Domain.Entities.Admins;
using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Common.Helpers;
using kudapoyti.Service.Common.Security;
using kudapoyti.Service.Dtos.Accounts;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.Interfaces.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Services.KudaPaytiService
{
    public class AdminAccountService : IAdminAccountService
    {
        private readonly IUnitOfWork _work;
        private readonly IAuthManager _auth;
        private readonly IImageService _image;

        public AdminAccountService(IUnitOfWork repository, IAuthManager authManager, IImageService image)
        {
            _work = repository;
            _auth = authManager;
            _image = image;
            
        }

        public async Task<string> LoginAsync(AdminAccountLoginDto loginDto)
        {
            var admin=await _work.Admins.FirstOrDefaoultAsync(x => x.Email==loginDto.Email);
            if (admin is null) throw new StatusCodeException(HttpStatusCode.NotFound, "Admin not found, Email is incorrect!");

            var hasherResult = PasswordHasher.Verify(loginDto.Password, admin.Salt, admin.PasswordHash);
            if (hasherResult)
            {
                return _auth.GenerateToken(admin);
            }
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "Password is wrong!");

        }

    }
}
