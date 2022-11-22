using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Infrastructure.Data.Confuguration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new List<IdentityRole>
            {
              new IdentityRole {
                Id ="25f73449-f9e8-40b4-87ee-93fc6c242339" ,
                Name = "Client",
                NormalizedName = "CLIENT"
              },
              new IdentityRole {
                Id = "eed2d778-89cf-4c3c-a710-c8d61811f4c7",
                Name = "Constructor",
                NormalizedName = "CONSTRUCTOR"
              },
            });
        }
    }
}
