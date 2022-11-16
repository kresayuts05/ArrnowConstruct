using ArrnowConstruct.Infrastructure.Data.Entities;
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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    { 
        public void Configure(EntityTypeBuilder<User> builder)
        {
            throw new NotImplementedException();
        }

        private List<User> CreateUsers()
        {
            var users = new List<User>();
            var hasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "kresa",
                NormalizedUserName = "KRESA",
                Email = "kresa@mail.com",
                NormalizedEmail = "KRESA@MAIL.COM",
                PhoneNumber = "0886121260",
                FirstName = "Kresa",
                LastName = "Tsvetkova",
                City = "Kazanlak",
                Address = "Edelvais 6 ",
                Country = "Bulgaria"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "constructor123");

            users.Add(user);

            user = new User()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "angel",
                NormalizedUserName = "ANGEL",
                Email = "guest@mail.com",
                NormalizedEmail = "ANGEL@MAIL.COM",
                PhoneNumber = "0888791001",
                FirstName = "Angel",
                LastName = "Momov",
                City = "Kazanlak",
                Address = "Petko DePetkov 71",
                Country = "Bulgaria"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "client123");

            users.Add(user);

            return users;
        }
    }
}
