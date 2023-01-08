using kudapoyti.DataAccess.DbConstexts;
using kudapoyti.DataAccess.Interfaces;
using kudapoyti.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.DataAccess.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected AppDbContext _dbContext { get; set; }
        protected DbSet<T> _dbset { get; set; }

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = dbContext.Set<T>();
        }

        public void CreateAsync(T entity)=> _dbset.Add(entity);
        

        public void DeleteAsync(long id)
        {
            var entity = _dbset.Find(id);
            if(entity is not null)
                _dbset.Remove(entity);
        }

        public async Task<T?> FindByIdAsync(long id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task<T?> FirstOrDefaoultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbset.FirstOrDefaultAsync(expression);
        }

        public void UpdateAsync(long id, T entity)
        {
            entity.Id = id;
            _dbset.Update(entity);
        }
    }
}
