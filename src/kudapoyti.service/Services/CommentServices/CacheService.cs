﻿using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Dtos.AccountDTOs;
using kudapoyti.Service.Interfaces.CommentServices;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Graph;
using Microsoft.Graph.SecurityNamespace;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Services.CommentServices
{
    public class CacheService:ICacheService
    {
        private IMemoryCache _cache;
        public CacheService(IMemoryCache memoryCache)
        {
            _cache= memoryCache;
        }
        public async Task<(string,UserValidateDto)> GetValueAsync()
        {
            try
            {
                var value = await _cache.GetOrCreateAsync("verifycode", entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                    return Task.FromResult(string.Empty);
                });
                var user = await _cache.GetOrCreateAsync("user", entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                    return Task.FromResult(string.Empty);
                });

                if (string.IsNullOrEmpty(value))
                {
                    throw new StatusCodeException(System.Net.HttpStatusCode.Forbidden, "Verification code time limit expired");
                }
                else
                {
                    var targetuser = JsonConvert.DeserializeObject<UserValidateDto>(user);
                    return (value,targetuser);
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task SetValueAsync(string code,UserValidateDto user)
        {
            var userJson = JsonConvert.SerializeObject(user);
            await Task.Run(() => _cache.Set("user", userJson, TimeSpan.FromMinutes(5)));
            await Task.Run(() => _cache.Set("verifycode", code, TimeSpan.FromMinutes(5)));
        }
    }
}
