using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.ViewModels
{
    public class PlaceViewModel
    {
        public long Id { get; set; }

        public string ImageUrl { get; set; }=String.Empty;

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double rank { get; set; }

        public string Location_link { get; set; } = String.Empty;

        public string PlaceSiteUrl { get; set; } = String.Empty;

        public string Region { get; set; } = String.Empty;

    } 
}
  