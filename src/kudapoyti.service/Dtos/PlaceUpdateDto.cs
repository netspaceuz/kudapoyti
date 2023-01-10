using kudapoyti.Domain.Entities.Places;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Dtos;
public class PlaceUpdateDto
{
    [Required(ErrorMessage = "Please enter a title that contains minimum 5 and maximum 50 characters.")]
    [MinLength(5)]
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a description that contains minimum 10 and maximum 100 characters.")]
    [MinLength(10)]
    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Plase etner the link of the location.")]
    public string LocationLink { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a region.")]
    public string Region { get; set; } = string.Empty;

    public string PlaceSiteUrl { get; set; } = string.Empty;

    [Required(ErrorMessage = "Plase upload a picture of the place.")]
    public IFormFile? Image { get; set; }

    public static implicit operator Place(PlaceUpdateDto dto)
    {
        return new Place()
        {
            Title = dto.Title,
            Description = dto.Description,
            Location_link = dto.LocationLink,
            PlaceSiteUrl = dto.PlaceSiteUrl,
            Region = dto.Region,
            ImageUrl = dto.Image!.ToString()
        };
    }
}
