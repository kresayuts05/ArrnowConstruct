using ArrnowConstruct.Infrastructure.Data;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using ArrnowConstruct.Tests.Mocks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected List<IdentityRole> roles;
        protected List<User> users;
        protected List<Client> clients;
        protected List<Constructor> constructors;
        protected List<Request> requests;
        protected List<Site> sites;
        protected List<Post> posts;
        protected List<Image> images;
        protected List<Category> categories;
        protected List<IdentityUserRole<string>> userRoles;

        protected ArrnowConstructDbContext context;

        [SetUp]
        public async Task SetUpBase()
        {
            this.context = DatabaseMock.Instance;
            await this.SeedData();
        }

        public async Task SeedData()
        {
            categories = new List<Category>() {
                new Category()
                {
                    Id = 1,
                    Name = "Kitchen"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Bathroom"
                },  new Category()
                {
                    Id = 3,
                    Name = "Bedroom"
                },
                new Category()
                {
                    Id = 4,
                    Name = "LivingRoom"
                },
                new Category()
                {
                    Id = 5,
                    Name = "DiningRoom"
                },
                new Category()
                {
                    Id = 6,
                    Name = "Hall"
                },
                new Category()
                {
                    Id = 7,
                    Name = "Office"
                }
            };

            await context.Categories.AddRangeAsync(categories);

            clients = new List<Client>
            {
                new Client() {
                    Id = 1,
                         User =  new User
                       {
                           Id = "ClientTestId",
                           UserName = "client",
                           Email = "client@gmail.com",
                           EmailConfirmed = true,
                           NormalizedEmail = "CLIENT@GMAIL.COM",
                           NormalizedUserName = "CLIENT",
                           FirstName = "Client",
                           LastName = "Client",
                           City = "Kazanlak",
                           Country = "Bulgaria",
                           Address = "jhgfcdcfygvubhinj"
                      }
                },
            };

            constructors = new List<Constructor>
            {
                new Constructor() {
                    Id = 1,
                         User =  new User
                       {
                           Id = "ConstructorTestId",
                           UserName = "constructor",
                           Email = "constructor@gmail.com",
                           EmailConfirmed = true,
                           NormalizedEmail = "CONSTRUCTOR@GMAIL.COM",
                           NormalizedUserName = "CONSTRUCTOR",
                           FirstName = "constructor",
                           LastName = "constructor",
                           City = "Kazanlak",
                           Country = "Bulgaria",
                           Address = "jhgfcdcfygvubhinj"
                      },
                         Salary = 1000
                },
            };

            roles = new List<IdentityRole>
                {
                    new IdentityRole
                    {
                        Id = "client",
                        Name = "Client",
                        NormalizedName = "CLIENT"
                    },
                    new IdentityRole
                    {
                        Id = "constructor",
                        Name = "Constructor",
                        NormalizedName = "CONSTRUCTOR"
                    }
                };

            userRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = "constructor",
                    UserId = "ConstructorTestId"
                }
            };


            requests = new List<Request>
            {
                new Request
                {
                   Id = 1,
                   RoomsCount = 2,
                   Area = 30,
                   RequiredDate = DateTime.UtcNow,
                   Budget = 2000,
                   Status = "Waiting",
                   ClientId = 1,
                   ConstructorId = 1,
                   RoomsTypes = new List<Category>(){categories[1], categories[2] }
                },
                new Request
                {
                   Id = 2,
                   RoomsCount = 7,
                   Area = 50,
                   RequiredDate = DateTime.UtcNow,
                   Budget = 2120,
                   Status = "Confirm",
                   ClientId = 1,
                   ConstructorId = 1,
                   RoomsTypes = new List<Category>(){categories[1], categories[2] },
                   IsActive = false
                },
                new Request
                {
                   Id = 3,
                   RoomsCount = 2,
                   Area = 30,
                   RequiredDate = DateTime.UtcNow,
                   Budget = 2000,
                   Status = "Rejected",
                   ClientId = 1,
                   ConstructorId = 1,
                   RoomsTypes = new List<Category>(){categories[1], categories[2] }
                },
            };

            sites = new List<Site>
            {
                new Site
                {
                   Id = 1,
                   RoomsCount = 2,
                   Area = 30,
                   FromDate = DateTime.UtcNow.AddDays(1),
                   ToDate = DateTime.UtcNow.AddDays(3),
                   Price = 2000,
                   Status = "InProcess",
                   ClientId = 1,
                   ConstructorId = 1,
                   RoomsTypes = new List<Category>(){categories[1], categories[2] }
                },
                 new Site
                {
                   Id = 2,
                   RoomsCount = 2,
                   Area = 30,
                   FromDate = DateTime.UtcNow.AddDays(1),
                   ToDate = DateTime.UtcNow.AddDays(3),
                   Price = 2000,
                   Status = "Finished",
                   ClientId = 1,
                   ConstructorId = 1,
                   RoomsTypes = new List<Category>(){categories[1], categories[2] }
                },
                      new Site
                {
                   Id = 3,
                   RoomsCount = 2,
                   Area = 30,
                   FromDate = DateTime.UtcNow.AddDays(1),
                   ToDate = DateTime.UtcNow.AddDays(3),
                   Price = 2000,
                   Status = "Disactivated",
                   ClientId = 1,
                   ConstructorId = 1,
                   RoomsTypes = new List<Category>(){categories[1], categories[2] }
                },
            };

            await context.Clients.AddRangeAsync(clients);
            await context.Constructors.AddRangeAsync(constructors);
            await context.Roles.AddRangeAsync(roles);
            await context.UserRoles.AddRangeAsync(userRoles);
            await context.Requests.AddRangeAsync(requests);
            await context.Sites.AddRangeAsync(sites);

            await context.SaveChangesAsync();
        }

        public async Task TearDownBase()
        {
            await this.context.DisposeAsync();
        }
    }
}