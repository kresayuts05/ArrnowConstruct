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
            builder.HasData(CreateUsers());
        }

        private List<User> CreateUsers()
        {
            var users = new List<User>();
            var hasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "babdaf39-3545-48e1-877e-13d4bb4d597f",
                UserName = "nikol",
                NormalizedUserName = "NIKOL",
                Email = "nikol@mail.com",
                NormalizedEmail = "NIKOL@MAIL.COM",
                PhoneNumber = "0886121261",
                FirstName = "Nikol",
                LastName = "Grueva",
                City = "Kazanlak",
                Address = "Graf Ignatiev 6 ",
                Country = "Bulgaria"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "123456");

            users.Add(user);

             user = new User()
            {
                Id = "ae724eb3-355b-48dd-bdaa-c1eaccf666c5",
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
                 hasher.HashPassword(user, "123456");

            users.Add(user);

            user = new User()
            {
                Id = "7125d323-7567-4f56-b27e-6b7044014a37",
                UserName = "angel",
                NormalizedUserName = "ANGEL",
                Email = "angel@mail.com",
                NormalizedEmail = "ANGEL@MAIL.COM",
                PhoneNumber = "0888791001",
                FirstName = "Angel",
                LastName = "Momov",
                City = "Kazanlak",
                Address = "Petko DePetkov 71",
                Country = "Bulgaria",
                ProfilePictureUrl = "https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-profiles/avatar-1.webp"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "123456");

            users.Add(user);

            return users;
        }
    }
}
