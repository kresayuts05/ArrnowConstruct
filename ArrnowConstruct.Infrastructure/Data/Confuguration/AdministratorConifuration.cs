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
    public class AdministratorConifuration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        private const string administratorRoleId = "4033acf9-98f0-49e3-aafc-fd4fcb71c67e";
        private const string administratorUserId = "ae724eb3-355b-48dd-bdaa-c1eaccf666c5";
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = administratorRoleId,
                UserId = administratorUserId
            });
        }
    }
}
