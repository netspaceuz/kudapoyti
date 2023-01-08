using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.ViewModels
{
    public class PlaceViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Rank { get; set; }

        public long RankedPoint { get; set; }

        public string LocationLink { get; set; } = String.Empty;

        public string PlaceSiteUrl { get; set; } = String.Empty;

        public string Region { get; set; } = String.Empty;

    } 
}
  