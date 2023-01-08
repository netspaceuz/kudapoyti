using kudapoyti.DataAccess.DbConstexts;
using kudapoyti.DataAccess.Interfaces;
using kudapoyti.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace kudapoyti.api.Configurations;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        string connectionString = builder.Configuration.GetConnectionString("DataBaseConnection");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
