using AutoMapper;
using kudapoyti.DataAccess.DbConstexts;
using kudapoyti.DataAccess.Interfaces;
using kudapoyti.Domain.Entities.Admins;
using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Common.Security;
using kudapoyti.Service.Common.Utils;
using kudapoyti.Service.Dtos;
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
        private readonly IImageService _image;
        private readonly IPaginationService _pager;
        private readonly IMapper _mapper;
        private readonly AppDbContext appDb;
        public AdminService(IUnitOfWork repository, AppDbContext appDb, IMapper mapper, IPaginationService pagination, IImageService image)
        {
            this._work = repository;
            this._mapper = mapper;
            this.appDb = appDb;
            this._image=image;
            this._pager=pagination;
        }
        public async Task<bool> DeleteAysnc(long id)
        {
           var delete=await _work.Admins.FindByIdAsync(id);
            if (delete is not null)
            {
                _work.Admins.DeleteAsync(id);
                var result = await _work.SaveChangesAsync();
                return result > 0;
            }
            else throw new StatusCodeException(HttpStatusCode.NotFound, "Admin not found");
        }

        public async Task<IEnumerable<AdminViewModel>> GetAllAysnc(PaginationParams @params)
        {
            var query = _work.Admins.GetAll().OrderBy(x => x.Id).Select(x => _mapper.Map<AdminViewModel>(x));
            var result = await _pager.ToPagedAsync(query, @params.PageNumber, @params.PageSize);
            return result;
        }
        public async Task<AdminViewModel> GetAysnc(long id)
        {
            var get = await _work.Admins.FindByIdAsync(id);
            if (get is not null)
            {
                var re= _mapper.Map<AdminViewModel>(get);
                return re;
            } 
            else throw new StatusCodeException(HttpStatusCode.NotFound, "Admin not faund");
        }
        public async Task<bool> RegisterAsync(AdminCreateDto registerDto)
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

        public async Task<bool> UpdateAysnc(long id, UpdateCreateDto dto)
        {
            var update = await appDb.Admins.FindAsync(id);
            appDb.Entry<Admin1>(update!).State=Microsoft.EntityFrameworkCore.EntityState.Detached;
            if (dto is not null)
            {
                var res = _mapper.Map<Admin1>(dto);
                res.Id = id;
                appDb.Admins.Update(res);
                var result = await appDb.SaveChangesAsync();
                return result > 0;
            }
            else throw new StatusCodeException(HttpStatusCode.NotFound, "Admin not faund");
        }
    }
}
