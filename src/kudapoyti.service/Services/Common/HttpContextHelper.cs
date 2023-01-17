﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Services.Common
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor Accessor { get; set; }
        public static HttpResponse Response => Accessor.HttpContext.Response;

        public static IHeaderDictionary ResponseHeaders => Response.Headers;

        public static HttpContext HttpContext => Accessor?.HttpContext;
        public static long AdminId => GetAdminId();

        public static string UserRole => HttpContext?.User.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
        private static long GetAdminId()
        {
            long id;
            bool canParse = long.TryParse(HttpContext.User?.Claims.FirstOrDefault(p => p.Type == "Id")?.Value, out id);
            return canParse ? id : 0;
        }
    }
}
