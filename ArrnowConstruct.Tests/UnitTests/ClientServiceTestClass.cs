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
    public class ClientServiceTestClass : UnitTestsBase
    {
        private IRepository repo;
        private IClientService clientService;

        [SetUp]
        public async Task Setup()
        {
            this.repo = new Repository(this.context);
            this.clientService = new ClientService(repo);
        }


        [Test]
        public async Task CreateClientShouldReturnCorectResult()
        {
            var user = new User
            {
                Id = "ClientTestId22",
                UserName = "client22",
                Email = "client22@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "CLIENT22@GMAIL.COM",
                NormalizedUserName = "CLIENT22",
                FirstName = "Client22",
                LastName = "Client22",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "jhgfcdcfygvubhinj"
            };

            await repo.AddAsync(user);
            await repo.SaveChangesAsync();

            await clientService.Create("ClientTestId22");

            var dbClient = await repo.GetByIdAsync<Client>(3);

            Assert.IsNotNull(dbClient);
            Assert.That(dbClient.UserId, Is.EqualTo("ClientTestId22"));
            Assert.That(dbClient.User.Email, Is.EqualTo("client22@gmail.com"));
        }

        [Test]
        [TestCase("admin")]
        public async Task GetAllClientsShouldReturnCorrectCollection(string id)
        {
            var dbClients = await repo.All<Client>()
                .Where(c => c.User.IsActive == true)
                .Select(c => c.User.Id)
                .ToListAsync();

            var allClientsInfo = (List<UserModel>)await clientService.GetAllClients(id);
            var allClients = allClientsInfo.Select(p => p.Id).ToList();

            Assert.AreEqual(allClients.Count, dbClients.Count);
            Assert.AreEqual(allClients, dbClients);
        }

        [Test]
        [TestCase("ClientTestId")]
        public async Task GetClientIdShouldReturnCorrectResult(string id)
        {
            var clientId = await clientService.GetClientId(id);

            var dbClient= await repo.GetByIdAsync<Client>(clientId);
            var dbUser = await repo.GetByIdAsync<User>(id);

            Assert.IsNotNull(dbClient);
            Assert.That(dbClient.UserId, Is.EqualTo(id));
            Assert.That(dbClient.User.Email, Is.EqualTo(dbUser.Email));
        }

        [Test]
        [TestCase("")]
        [TestCase("sth")]
        [TestCase("ConstructorTestId")]
        [TestCase("ClientTestId2")]
        [TestCase("ConstructorTestIdDisactivaated")]
        [TestCase(null)]
        public async Task GetRequestStatusShouldThrowNullReferenceException(string id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await clientService.GetClientId(id));
            Assert.AreEqual(GlobalExceptions.ClientDoessNotExistsExceptionMessage, ex.Message);
        }


        [Test]
        [TestCase(1)]
        public async Task GetUserByClientIdShouldReturnCorrectResult(int id)
        {
            var user = await clientService.GetUserByClientId(id);

            var dbClient = await repo.GetByIdAsync<Client>(id);

            Assert.IsNotNull(user);
            Assert.That(dbClient.UserId, Is.EqualTo(user.Id));
            Assert.That(dbClient.User.Email, Is.EqualTo(user.Email));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(null)]
        [TestCase(7)]
        public async Task GetUserByClientIdShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await clientService.GetUserByClientId(id));
            Assert.AreEqual(GlobalExceptions.ClientDoessNotExistsExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(1)]
        public async Task DisactivateClientShouldChangeStatusSuccessfully(int id)
        {
            await clientService.DisactivateClient(id);
            var dbClient = await repo.GetByIdAsync<Client>(id);

            Assert.AreEqual(dbClient.IsActive, false);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task DisactivateClientShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await clientService.DisactivateClient(id));
            Assert.AreEqual(GlobalExceptions.ClientDoessNotExistsExceptionMessage, ex.Message);
        }


        [Test]
        [TestCase("ClientTestId")]
        public async Task ExistConstructorShouldReturnTrue(string id)
        {
            var dbRequest = await clientService.ExistsById(id);

            Assert.That(dbRequest, Is.EqualTo(true));
        }

        [Test]
        [TestCase("")]
        [TestCase("sth")]
        [TestCase("ClientTestId2")]
        [TestCase("ConstructorTestIdDisactivaated")]
        [TestCase(null)]
        public async Task ExistConstructorShouldReturnFalse(string id)
        {
            var dbRequest = await clientService.ExistsById(id);
            Assert.That(dbRequest, Is.EqualTo(false));
        }
    }
}
