using kudapoyti.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Domain.Entities.Places;

public class Place:Auditable
{
    public string Title { get; set; }=string.Empty;
   
    public string Description { get; set; }=string.Empty;

    public string? ImageUrl { get; set; }

    public double rank { get; set; }

    public long rankedUsersCount { get; set; }    

    public long Ranked_point { get; set; }

    public string Location_link { get; set; }=String.Empty;

    public string PlaceSiteUrl { get; set; }=String.Empty;

    public string Region { get; set; } = String.Empty;
}
