using kudapoyti.DataAccess.Interfaces.Admins;
using kudapoyti.DataAccess.Interfaces.Comments;
using kudapoyti.DataAccess.Interfaces.Photos;
using kudapoyti.DataAccess.Interfaces.Places;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.DataAccess.Interfaces;

public interface IUnitOfWork
{
    public IAdminRepository Admins { get; }
    
    public ICommentsRepository Comments { get; }
    
    public IPhotoRepository Photos { get; }
    
    public IPlaceRepository Places { get; }

    public Task<int> SaveChangesAsync();
    public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
}
