using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Interfaces
{
    public interface IAuthenticationAttribute
    {
        public bool IsAuthed(List<string> rols, HttpContext httpContext);
    }
}
