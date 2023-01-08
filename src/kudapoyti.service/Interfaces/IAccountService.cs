using kudapoyti.Service.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Interfaces
{
    public interface IAccountService
    {
        public Task<bool> RegisterAsync(AdminAccountRegisterDto account);
        public Task<string> LoginAsync(AdminAccountLoginDto account);
    }
}
