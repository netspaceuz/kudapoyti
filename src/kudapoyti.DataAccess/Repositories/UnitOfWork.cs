using kudapoyti.DataAccess.DbConstexts;
using kudapoyti.DataAccess.Interfaces;
using kudapoyti.DataAccess.Interfaces.Admins;
using kudapoyti.DataAccess.Interfaces.Comments;
using kudapoyti.DataAccess.Interfaces.Photos;
using kudapoyti.DataAccess.Interfaces.Places;
using kudapoyti.DataAccess.Repositories.Admins;
using kudapoyti.DataAccess.Repositories.Comments;
using kudapoyti.DataAccess.Repositories.Photos;
using kudapoyti.DataAccess.Repositories.Places;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public IAdminRepository Admins { get; }

        public ICommentsRepository Comments { get; }

        public IPhotoRepository Photos { get; } 

        public IPlaceRepository Places { get; }

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Admins = new AdminRepository(_dbContext);
            Comments = new CommentRepository(_dbContext);
            Photos = new PhotoRepository(_dbContext);
            Places = new PlaceRepository(_dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return _dbContext.Entry(entity);
        }
    }
}
