using kudapoyti.Service.Dtos.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Interfaces.CommentServices
{
    public interface ICacheService
    {
        public Task SetValueAsync(string email,string code,UserValidateDto user);
        public Task<(string,UserValidateDto)> GetValueAsync(string email);
    }
}
