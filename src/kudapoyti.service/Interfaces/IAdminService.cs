using kudapoyti.Domain.Entities.Admins;
using kudapoyti.Service.Common.Utils;
using kudapoyti.Service.Dtos;
using kudapoyti.Service.Dtos.Accounts;
using kudapoyti.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Interfaces
{
    public interface IAdminService
    {
        public Task<IEnumerable<AdminViewModel>> GetAllAysnc(PaginationParams @params); 
        public Task<AdminViewModel> GetAysnc(long id);
        public Task<bool> RegisterAsync(AdminCreateDto account);
        public Task<bool> UpdateAysnc(long id,UpdateCreateDto dto);    
        public Task<bool> DeleteAysnc(long id);
    }
}
