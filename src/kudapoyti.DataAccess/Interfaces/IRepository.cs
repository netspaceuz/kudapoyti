using kudapoyti.Domain.Common;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> FindByIdAsync(long id);

        public Task<T?> FirstOrDefaoultAsync(Expression<Func<T, bool>> expression);

        public void CreateAsync(T entity);

        public void DeleteAsync(long id);

        public void UpdateAsync(long id ,T entity);
    }
}
