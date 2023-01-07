using kudapoyti.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<bool> CreateAsync(T entity);
    }
}
