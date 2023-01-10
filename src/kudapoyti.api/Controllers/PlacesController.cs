using kudapoyti.Domain.Constants;
using kudapoyti.Domain.Entities.Places;
using kudapoyti.Service.Common.Utils;
using kudapoyti.Service.Dtos;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.Interfaces.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kudapoyti.api.Controllers
{
    [Route("api/places")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        private readonly IPaginationService _pager;
        private readonly int _pageSize = PageSize.PAGESIZE;

        public PlacesController(IPlaceService placeService)
        {
            this._placeService = placeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int page) 
            => Ok(await _placeService.GetAllAsync(new PaginationParams(page, _pageSize)));

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long id) 
            => Ok(await _placeService.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] PlaceCreateDto dto) 
            => Ok(await _placeService.CreateAsync(dto));

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id) 
            => Ok(await _placeService.DeleteAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateByIdAsync(long id, [FromForm] PlaceUpdateDto obj) 
            => Ok(await _placeService.UpdateAsync(id, obj));
    }
}
