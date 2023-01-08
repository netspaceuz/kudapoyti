using kudapoyti.Service.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Interfaces.Common
{
    public interface IEmailService
    {
        public Task<bool> SendAsync(EmailMessage emailMessage);
    }
}
