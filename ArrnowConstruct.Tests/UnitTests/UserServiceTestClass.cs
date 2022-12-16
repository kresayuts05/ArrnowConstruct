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
    public class UserServiceTestClass : UnitTestsBase
    {
        private IRepository repo;
        private IUserService userService;

        [SetUp]
        public async Task Setup()
        {
            this.repo = new Repository(this.context);
            this.userService = new UserService(repo);
        }

        [Test]
        [TestCase("ClientTestId")]
        [TestCase("ConstructorTestId")]
        public async Task GetClientIdShouldReturnCorrectResult(string id)
        {
            var user = await userService.GetUserById(id);

            var dbUser = await repo.GetByIdAsync<User>(id);

            Assert.IsNotNull(user);
            Assert.That(user.Id, Is.EqualTo(id));
            Assert.That(user.Email, Is.EqualTo(dbUser.Email));
            Assert.That(user.Phone, Is.EqualTo(dbUser.PhoneNumber));
            Assert.That(user.Address, Is.EqualTo(dbUser.Address));
            Assert.That(user.City, Is.EqualTo(dbUser.City));
        }

        [Test]
        [TestCase("")]
        [TestCase("sth")]
        [TestCase("ClientTestId2")]
        [TestCase("ConstructorTestIdDisactivaated")]
        [TestCase(null)]
        public async Task GetRequestStatusShouldThrowNullReferenceException(string id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await userService.GetUserById(id));
            Assert.AreEqual(GlobalExceptions.UserDoesNotExistExceptionMessage, ex.Message);
        }


        [Test]
        [TestCase("ae724eb3-355b-48dd-bdaa-c1eaccf666c5")]
        public async Task AllUsersShouldReturnCorrectCollection(string admin)
        {
            var dbUsers = await repo.All<User>()
                .Where(u => u.Id != admin && u.IsActive == true)
                .ToListAsync();

            var allUser = (List<UserModel>)await userService.AllUsers(admin);

            Assert.AreEqual(dbUsers.Count, allUser.Count);
            Assert.AreEqual(dbUsers[1].Id, allUser[1].Id);
        }


        [Test]
        [TestCase("ClientTestId")]
        public async Task DeleteUserShouldChangeStatusSuccessfully(string id)
        {
            await userService.Delete(id);
            var dbUser = await repo.GetByIdAsync<User>(id);

            Assert.AreEqual(dbUser.IsActive, false);
        }

        [Test]
        [TestCase("")]
        [TestCase("sth")]
        [TestCase("ClientTestId2")]
        [TestCase("ConstructorTestIdDisactivaated")]
        [TestCase(null)]
        public async Task DisactivateClientShouldThrowNullReferenceException(string id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await userService.Delete(id));
            Assert.AreEqual(GlobalExceptions.UserDoesNotExistExceptionMessage, ex.Message);
        }


        [Test]
        [TestCase("client@gmail.com")]
        public async Task UserExistsByEmailShouldReturnTrue(string email)
        {
            var dbUser = await userService.UserByEmailExists(email);

            Assert.That(dbUser, Is.EqualTo(true));
        }

        [Test]
        [TestCase("")]
        [TestCase("sth")]
        [TestCase("client2@gmail.com")]
        [TestCase("constructor@gmail.co")]
        [TestCase(null)]
        public async Task UserExistsByEmaiilShouldReturnFalse(string email)
        {
            var dbUser = await userService.UserByEmailExists(email);
            Assert.That(dbUser, Is.EqualTo(false));
        }
    }
}
