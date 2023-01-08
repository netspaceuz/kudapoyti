using kudapoyti.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Domain.Entities.Photos
{
    public class Photo:BaseEntity
    {
        public string Photo_path { get; set; } = String.Empty;
        
        public long PlaceId { get; set; }
        public virtual Places.Place Place { get; set; } = null!;
    }
}

