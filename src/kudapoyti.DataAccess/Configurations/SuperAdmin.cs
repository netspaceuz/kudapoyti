using kudapoyti.Domain.Entities.Admins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.DataAccess.Configurations;

public class SuperAdmin : IEntityTypeConfiguration<Admin1>
{
    public void Configure(EntityTypeBuilder<Admin1> builder)
    {
        builder.HasData(new Admin1()
        {
            Id=1,
            FullName="Kudapayti",
            Email="Kudapayti@gmail.com",
            PhoneNumber="+998999909090",
            TelegramLink= "https://t.me/Shoxrux_Husenov",
            Description=" ",
            PasswordHash= "$2a$11$pUC4LQVORynSuk0xn/Wl9ujn3e8NVGIa9rs8WUliW4USW5FY/BhOG",
            Salt= "f1fd3ecc-32c8-430d-ae6d-288eb2753c43",
            

        });
    }
}
