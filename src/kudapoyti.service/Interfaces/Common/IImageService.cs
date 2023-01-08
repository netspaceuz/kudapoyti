using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Interfaces.Common
{
    public interface IImageService
    {
        public Task<string> SaveImageAsync(IFormFile file);
        public Task<bool> DeleteImageAsync(string imagePath);
    }
}
