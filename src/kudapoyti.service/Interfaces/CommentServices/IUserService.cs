using kudapoyti.Service.Dtos.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Interfaces.CommentServices
{
    public interface IUserService
    {
        public Task LoginAsync(UserValidateDto userValidate);
        public Task<(bool, string)> VerifyCodeAsync(string email,string code);
    }
}
