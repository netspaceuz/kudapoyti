using kudapoyti.Domain.Entities.Places;
using kudapoyti.Service.Common.Utils;
using kudapoyti.Service.Dtos;
using kudapoyti.Service.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Interfaces
{
    public interface IPlaceService
    {

        public Task<IEnumerable<Place>> GetAllAsync(PaginationParams @paginationParams);
        public Task<PlaceViewModel> GetAsync(long id);
        public Task<bool> UpdateAsync(long id, PlaceUpdateDto updateDto);
        public Task<bool> DeleteAsync(long id);
        public Task<bool> CreateAsync(PlaceCreateDto createDto);
    }
}
