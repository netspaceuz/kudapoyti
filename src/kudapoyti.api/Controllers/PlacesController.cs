using kudapoyti.Domain.Constants;
using kudapoyti.Domain.Entities.Places;
using kudapoyti.Service.Common.Exceptions;
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
        private readonly IAuthenticationAttribute _auth;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PlacesController(IPlaceService placeService,IAuthenticationAttribute authentication, IHttpContextAccessor contextAccessor)
        {
            this._placeService = placeService;
            this._auth = authentication;
            _httpContextAccessor = contextAccessor;
        }
        [HttpGet("{page}"),AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(int page)
            => Ok(await _placeService.GetAllAsync(new PaginationParams(page, _pageSize)));

        [HttpGet("[action]/{id}"), AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long id) 
            => Ok(await _placeService.GetAsync(id));
        [HttpGet("[action]/{cityName}"),AllowAnonymous]
        public async Task<IActionResult> GetByCityAsync(string cityName)
            => Ok(await _placeService.GetByCityAsync(cityName));
        [HttpGet("[action]/{keyword}"),AllowAnonymous]
        public async Task<IActionResult> SearchAsync(string keyword)
            => Ok(await _placeService.GetByKeyword(keyword));

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] PlaceCreateDto dto)
        {
            List<string> rols = new List<string>() { "SuperAdmin", "Admin" };
            if (_auth.IsAuthed(rols, _httpContextAccessor.HttpContext))
            {
                return Ok(await _placeService.CreateAsync(dto));
            }
            else
                throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "You haven't got access");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            List<string> rols = new List<string>() { "SuperAdmin", "Admin" };
            if (_auth.IsAuthed(rols, _httpContextAccessor.HttpContext))
            {
                return Ok(await _placeService.DeleteAsync(id));
            }
            else
                throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "You haven't access");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateByIdAsync(long id, [FromForm] PlaceUpdateDto obj)
        {
            List<string> rols = new List<string>() { "SuperAdmin","Admin" };
            if (_auth.IsAuthed(rols, _httpContextAccessor.HttpContext))
            {
                return Ok(await _placeService.UpdateAsync(id, obj));
            }
            else
                throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "You haven't access");
        }
        
        [HttpPut("[action]/{placeId}"), AllowAnonymous]
        public async Task<IActionResult> RankAsync(long placeId, int rank )
            =>Ok(await _placeService.AddRankPoint(placeId, rank));
        [HttpGet("[action]"),AllowAnonymous]
        public async Task<IActionResult> GetByTypesAsync(int page,string type)
            => Ok(await _placeService.GetByTypeAsync(new PaginationParams(page, _pageSize),type));

        [HttpGet("[action]"),AllowAnonymous]
        public async Task<IActionResult> GetOtherTypesAsync()
            => Ok(await _placeService.GetOtherTypes());
        [HttpGet("[action]"),AllowAnonymous]
        public async Task<IActionResult> GetTopPlacesAsync()
            => Ok(await _placeService.GetTopPLacesAsync());
    }
}