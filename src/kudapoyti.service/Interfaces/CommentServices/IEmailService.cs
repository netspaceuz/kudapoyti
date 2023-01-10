using kudapoyti.Service.Dtos.AccountDTOs;
using kudapoyti.Service.Dtos.Common;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Interfaces.CommentServices
{
    public interface IEmailService
    {
        public Task SendAsync(UserValidateDto user);
    }
}
