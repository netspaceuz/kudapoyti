using kudapoyti.Domain.Entities.Places;
using kudapoyti.Service.Dtos.Places;
using kudapoyti.Service.Interfaces;
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

        public PlacesController(IPlaceService placeService)
        {
            this._placeService = placeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() 
            => Ok(await _placeService.GetAllAsync());

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
        public async Task<IActionResult> UpdateByIdAsync(long id, [FromBody] PlaceCreateDto dto) 
            => Ok(await _placeService.UpdateAsync(id, dto));
    }
}
