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
    public class UsersRolesConifiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(GiveUsersRoles());
        }

        private List<IdentityUserRole<string>> GiveUsersRoles()
        {
            var users = new List<IdentityUserRole<string>>();

            users.Add(new IdentityUserRole<string>()
            {
               RoleId = "25f73449-f9e8-40b4-87ee-93fc6c242339",
               UserId = "babdaf39-3545-48e1-877e-13d4bb4d597f"
            });

            users.Add(new IdentityUserRole<string>()
            {
                RoleId = "4033acf9-98f0-49e3-aafc-fd4fcb71c67e",
                UserId = "ae724eb3-355b-48dd-bdaa-c1eaccf666c5"
            });

            users.Add(new IdentityUserRole<string>()
            {
                RoleId = "eed2d778-89cf-4c3c-a710-c8d61811f4c7",
                UserId = "7125d323-7567-4f56-b27e-6b7044014a37"
            });

            return users;
        }
    }
}
