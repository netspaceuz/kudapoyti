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

    public double Rank { get; set; }

    public long RankedUsersCount { get; set; }    

    public long RankedPoint { get; set; }

    public string LocationLink { get; set; }=String.Empty;

    public string PlaceSiteUrl { get; set; }=String.Empty;

    public string Region { get; set; } = String.Empty;

}
