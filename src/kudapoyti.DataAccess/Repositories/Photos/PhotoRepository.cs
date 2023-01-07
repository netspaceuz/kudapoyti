using kudapoyti.DataAccess.DbConstexts;
using kudapoyti.DataAccess.Interfaces.Photos;
using kudapoyti.Domain.Entities.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.DataAccess.Repositories.Photos;

public class PhotoRepository:GenericRepository<Photo>, IPhotoRepository
{
    public PhotoRepository(AppDbContext context) : base(context)
    {

    }
}
