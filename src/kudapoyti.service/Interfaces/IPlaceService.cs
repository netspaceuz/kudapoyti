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
        public Task<IEnumerable<PlaceViewModel>> GetAllAsync(PaginationParams @paginationParams);
        public Task<bool> UpdateAsync(long id, PlaceUpdateDto updateDto);
        public Task<PlaceViewModel> GetAsync(long id);
        public Task<IEnumerable<PlaceViewModel>> GetByKeyword(string keyword);
        public Task<IEnumerable<PlaceViewModel>> GetByCityAsync(string cityName);
        public Task<bool> DeleteAsync(long id);
        public Task<bool> CreateAsync(PlaceCreateDto createDto);
        public Task<bool> AddRankPoint(long placeId, int rank);
        public Task<IEnumerable<PlaceViewModel>> GetTopPLacesAsync();
        public Task<IEnumerable<PlaceViewModel>> GetByTypeAsync(PaginationParams @paginationParams, string type);
        public Task<IEnumerable<string>> GetOtherTypes();

    }
}
