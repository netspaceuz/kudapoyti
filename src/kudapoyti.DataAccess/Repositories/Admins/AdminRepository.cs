using kudapoyti.DataAccess.DbConstexts;
using kudapoyti.DataAccess.Interfaces.Admins;
using kudapoyti.Domain.Entities.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.DataAccess.Repositories.Admins;

public class AdminRepository:GenericRepository<Admin1>,IAdminRepository
{
    public AdminRepository(AppDbContext context) : base(context)
    {

    }
}
