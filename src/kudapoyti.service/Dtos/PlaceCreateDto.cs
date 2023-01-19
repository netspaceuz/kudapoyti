using kudapoyti.Domain.Entities.Places;
using kudapoyti.Service.Common.Attributes;
using Microsoft.AspNetCore.Http;
using Npgsql.Internal.TypeHandlers.DateTimeHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Dtos
{
    public class PlaceCreateDto
    {
        [Required]
        [StringLength(200, MinimumLength =5, ErrorMessage ="The Title should be minimum 5 and maximum 200 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a type of the place.")]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Plase etner the link of the location.")]
        public string LocationLink { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please select a region.")]
        public string Region { get; set; } = string.Empty;

        [Required(ErrorMessage ="Plase upload a picture of the place.")]
        [ImageFile(ErrorMessage = "Please upload a valid image file")]
        public IFormFile? Image { get; set; }

        public static implicit operator Place(PlaceCreateDto dto)
        {
            return new Place()
            {
                Title = dto.Title,
                Description = dto.Description,
                Location_link = dto.LocationLink,
                PlaceSiteUrl = dto.Type,
                Region = dto.Region,
                ImageUrl = dto.Image!.ToString()
            };
        }

    }
}
