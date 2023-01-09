using kudapoyti.Domain.Entities.Places;
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
        [Required(ErrorMessage = "Please enter a title that contains minimum 5 and maximum 50 characters.")]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description that contains minimum 10 and maximum 100 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Plase etner the link of the location.")]
        public string LocationLink { get; set; } = string.Empty;

        [Required]
        public string Region { get; set; } = string.Empty;

        public string PlaceSiteUrl { get; set; } = string.Empty;
        public static implicit operator Place(PlaceCreateDto dto)
        {
            return new Place()
            {
                Title = dto.Title,
                Description = dto.Description,
                Location_link = dto.LocationLink,
                PlaceSiteUrl = dto.PlaceSiteUrl,
                Region = dto.Region,
            };
        }

    }
}
