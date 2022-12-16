using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Exceptions;
using ArrnowConstruct.Core.Models.User;
using ArrnowConstruct.Core.Services;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Tests.UnitTests
{
    [TestFixture]
    public class ConstructorServiceTestClass : UnitTestsBase
    {
        private IRepository repo;
        private IConstructorService constructorService;

        [SetUp]
        public async Task Setup()
        {
            this.repo = new Repository(this.context);
            this.constructorService = new ConstructorService(repo);
        }


        [Test]
        public async Task CreateConstructorShouldReturnCorectResult()
        {
            var user = new User
            {
                Id = "ConstructorTestId2",
                UserName = "constructor2",
                Email = "constructor2@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "CONSTRUCTOR2@GMAIL.COM",
                NormalizedUserName = "CONSTRUCTOR2",
                FirstName = "constructor2",
                LastName = "constructor2",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "jhgfcdcfygvubhinj"
            };

            await repo.AddAsync(user);
            await repo.SaveChangesAsync();

            await constructorService.Create("ConstructorTestId2", 1200);

            var dbConstructor = await repo.GetByIdAsync<Constructor>(3);

            Assert.IsNotNull(dbConstructor);
            Assert.That(dbConstructor.UserId, Is.EqualTo("ConstructorTestId2"));
            Assert.That(dbConstructor.Salary, Is.EqualTo(1200));
        }


        [Test]
        [TestCase("ConstructorTestId")]
        public async Task ExistConstructorShouldReturnTrue(string id)
        {
            var dbRequest = await constructorService.ExistsById(id);

            Assert.That(dbRequest, Is.EqualTo(true));
        }

        [Test]
        [TestCase("")]
        [TestCase("sth")]
        [TestCase("ClientTestId")]
        [TestCase("ConstructorTestIdDisactivaated")]
        [TestCase(null)]
        public async Task ExistConstructorShouldReturnFalse(string id)
        {
            var dbRequest = await constructorService.ExistsById(id);
            Assert.That(dbRequest, Is.EqualTo(false));
        }


        [Test]
        [TestCase("ConstructorTestId")]
        public async Task GetConstructorIdShouldReturnCorrectResult(string id)
        {
            var constructorId = await constructorService.GetConstructorId(id);

            var dbConstructor = await repo.GetByIdAsync<Constructor>(constructorId);
            var dbUser = await repo.GetByIdAsync<User>(id);

            Assert.IsNotNull(dbConstructor);
            Assert.That(dbConstructor.UserId, Is.EqualTo(id));
            Assert.That(dbConstructor.User.Email, Is.EqualTo(dbUser.Email));
        }

        [Test]
        [TestCase("")]
        [TestCase("sth")]
        [TestCase("ClientTestId")]
        [TestCase("ConstructorTestIdDisactivaated")]
        [TestCase(null)]
        public async Task GetRequestStatusShouldThrowNullReferenceException(string id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await constructorService.GetConstructorId(id));
            Assert.AreEqual(GlobalExceptions.ConstructorDoesNotExistExceptionMessage, ex.Message);
        }


        [Test]
        [TestCase("constructor@gmail.com")]
        public async Task ConstructorWithEmailExistsShouldReturnCorrectResult(string email)
        {
            var constructorId = await constructorService.ConstructorWithEmailExists(email);

            var dbConstructor = await repo.GetByIdAsync<Constructor>(constructorId);
            var dbUser = await repo.GetByIdAsync<User>(dbConstructor.UserId);

            Assert.IsNotNull(dbConstructor);
            Assert.That(dbConstructor.UserId, Is.EqualTo(dbUser.Id));
            Assert.That(dbConstructor.User.Email, Is.EqualTo(email));
        }

        [Test]
        [TestCase("")]
        [TestCase("sth")]
        [TestCase("CONSTRUCTOR@GMAIL.CO")]
        [TestCase("constructor@gmail.co")]
        [TestCase("CLIENT@GMAIL.COM")]
        [TestCase("client@gmail.com")]
        [TestCase(null)]
        public async Task ConstructorWithEmailExistsShouldThrowNullReferenceException(string email)
        {
            var result =  await constructorService.ConstructorWithEmailExists(email);
            Assert.AreEqual(result, -1);
        }


        [Test]
        public async Task GetAllConstructorsShouldReturnCorrectCollection()
        {
            var dbConstructors = await repo.All<Constructor>()
                .Where(c => c.User.IsActive == true)
                .Select(c => c.Id)
                .ToListAsync();

            var allConstructorsInfo =(List<ConstructorModel>) await constructorService.GetAllConstructors();
            var allConstructors = allConstructorsInfo.Select(p => p.ConstructorId).ToList();

            Assert.AreEqual(allConstructors.Count, dbConstructors.Count);
            Assert.AreEqual(allConstructors, dbConstructors);
        }

        [Test]
        [TestCase(1)]
        public async Task ConstructorWithEmailExistsShouldReturnCorrectResult(int id)
        {
            var constructorEmail = await constructorService.GetConstructorEmail(id);

            var dbConstructor = await repo.GetByIdAsync<Constructor>(id);

            Assert.IsNotNull(dbConstructor);
            Assert.That(dbConstructor.User.Email, Is.EqualTo(constructorEmail));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task GetConstructorEmailShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await constructorService.GetConstructorEmail(id));
            Assert.AreEqual(GlobalExceptions.ConstructorDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(1)]
        public async Task DisactivateConstructorShouldChangeStatusSuccessfully(int id)
        {
            await constructorService.DisactivateConstructor(id);
            var dbConstructor = await repo.GetByIdAsync<Constructor>(id);

            Assert.AreEqual(dbConstructor.IsActive, false);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task DisactivateConstructorShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await constructorService.DisactivateConstructor(id));
            Assert.AreEqual(GlobalExceptions.ConstructorDoesNotExistExceptionMessage, ex.Message);
        }
    }
}
