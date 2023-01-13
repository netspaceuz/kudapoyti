using kudapoyti.Domain.Entities.Admins;
using kudapoyti.Service.Dtos.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Common.Security
{
    public interface IAuthManager
    {
        public string GenerateToken(dynamic admin);
    }
}
