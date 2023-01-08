using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Common.Exceptions
{
    public class StatusCodeException: Exception
    {
        public StatusCodeException(string message): base(message) { }
    }
}
