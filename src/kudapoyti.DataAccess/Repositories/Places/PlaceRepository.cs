using kudapoyti.DataAccess.DbConstexts;
using kudapoyti.DataAccess.Interfaces.Places;
using kudapoyti.Domain.Entities.Places;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.DataAccess.Repositories.Places
{
    public class PlaceRepository:GenericRepository<Place>,IPlaceRepository
    {
        public PlaceRepository(AppDbContext context) : base(context)
        {

        }
    }
}
