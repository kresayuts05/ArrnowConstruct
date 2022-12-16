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
                Id = "ClientTestId2",
                UserName = "client2",
                Email = "client2@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "CLIENT2@GMAIL.COM",
                NormalizedUserName = "CLIENT2",
                FirstName = "Client2",
                LastName = "Client2",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "jhgfcdcfygvubhinj"
            };

            await repo.AddAsync(user);
            await repo.SaveChangesAsync();

            await clientService.Create("ClientTestId2");

            var dbClient = await repo.GetByIdAsync<Client>(3);

            Assert.IsNotNull(dbClient);
            Assert.That(dbClient.UserId, Is.EqualTo("ClientTestId2"));
            Assert.That(dbClient.User.Email, Is.EqualTo("client2@gmail.com"));
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
    }
}
