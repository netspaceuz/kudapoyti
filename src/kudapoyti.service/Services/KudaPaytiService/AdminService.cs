using kudapoyti.DataAccess.Interfaces;
using kudapoyti.Domain.Entities.Admins;
using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Common.Security;
using kudapoyti.Service.Common.Utils;
using kudapoyti.Service.Dtos.Accounts;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.Interfaces.Common;
using kudapoyti.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Services.KudaPaytiService
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _work;
        private readonly IAuthManager _auth;
        private readonly IImageService _image;

        public AdminService(IUnitOfWork repository, IAuthManager authManager, IImageService image)
        {
            _work = repository;
            _auth = authManager;
            _image = image;
        }

        public Task<bool> DeleteAysnc(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdminViewModel>> GetAllAysnc(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<AdminViewModel> GetAysnc(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(AdminAccountRegisterDto registerDto)
        {
            var emailcheck = await _work.Admins.FirstOrDefaoultAsync(x => x.Email == registerDto.Email);
            if (emailcheck is not null)
                throw new StatusCodeException(HttpStatusCode.Conflict, "Email alredy exist");

            var hasherResult = PasswordHasher.Hash(registerDto.Password);
            var admin = (Admin1)registerDto;
            admin.PasswordHash = hasherResult.passwordHash;
            admin.Salt = hasherResult.salt;
            _work.Admins.CreateAsync(admin);
            var databaseResult = await _work.SaveChangesAsync();
            return databaseResult > 0;
        }

        public Task<bool> UpdateAysnc(long id, AdminAccountRegisterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
