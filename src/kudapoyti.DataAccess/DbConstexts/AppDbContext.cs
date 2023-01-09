using kudapoyti.DataAccess.Configurations;
using kudapoyti.Domain.Entities.Admins;
using kudapoyti.Domain.Entities.Comment;
using kudapoyti.Domain.Entities.Photos;
using kudapoyti.Domain.Entities.Places;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.DataAccess.DbConstexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) :
        base(dbContextOptions)
    {

    }

    public virtual DbSet<Admin1> Admins { get; set; } = default!;
    public virtual DbSet<Comment> Comments { get; set; }=default!;
    public virtual DbSet<Photo> Photos { get;  set; } = default!;
    public virtual DbSet<Place> Places { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        _ = modelBuilder.ApplyConfiguration(new SuperAdmin());
    }
}
