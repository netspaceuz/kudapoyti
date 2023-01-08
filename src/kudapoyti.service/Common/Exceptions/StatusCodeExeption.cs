using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Common.Exceptions
{
    public class StatusCodeExeption:Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public StatusCodeExeption(HttpStatusCode statusCode,string message)
            :base(message)
        {
            StatusCode = statusCode;
        }
    }
}
