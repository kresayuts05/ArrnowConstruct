using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Exceptions;
using ArrnowConstruct.Core.Models.Category;
using ArrnowConstruct.Core.Models.Request;
using ArrnowConstruct.Core.Services;
using ArrnowConstruct.Infrastructure.Data;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using ArrnowConstruct.Tests.Mocks;
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
    [TestFixture]
    public class RequestServiceTestClass : UnitTestsBase
    {
        private IRepository repo;
        private IRequestService requestService;
        private ICategoryService categoryService;
        private IConstructorService constructorService;
        private IClientService clientService;

        [SetUp]
        public async Task Setup()
        {
            this.repo = new Repository(this.context);
            this.categoryService = new CategoryService(repo);
            this.constructorService = new ConstructorService(repo);
            this.clientService = new ClientService(repo);
            this.requestService = new RequestService(repo, categoryService, constructorService, clientService);
        }


        [Test]
        public async Task CreateRequestShouldReturnCorectResult()
        {
            await requestService.Create(new AddRequestViewModel()
            {
                RoomsCount = 2,
                Area = 80,
                RequiredDate = "2022-12-15",
                Budget = 2300,
                ConstructorEmail = "constructor@gmail.com",
                CategoryId = new List<int>() { 2, 3 }
            }, 1);

            var dbRequest = await repo.GetByIdAsync<Request>(4);

            Assert.IsNotNull(dbRequest);
            Assert.That(dbRequest.Budget, Is.EqualTo(2300));
        }

        [Test]
        public async Task CreateRequestShouldHaveCorrestCategories()
        {
            await requestService.Create(new AddRequestViewModel()
            {
                RoomsCount = 2,
                Area = 80,
                RequiredDate = "2022-12-15",
                Budget = 2300,
                ConstructorEmail = "constructor@gmail.com",
                CategoryId = new List<int>() { 2, 3 }
            }, 1);

            var dbRequest = await repo.GetByIdAsync<Request>(4);
            var firstElement = dbRequest.RoomsTypes.First();

            Assert.That(dbRequest.RoomsTypes.Count, Is.EqualTo(2));
            Assert.That(firstElement.Id, Is.EqualTo(2));
        }


        [Test]
        public async Task CreateRequestShouldThrowNullException()
        {
            var model = new AddRequestViewModel()
            {
                RoomsCount = 7,
                Area = 50,
                RequiredDate = "2022-12-11",
                Budget = 2120,
                ConstructorEmail = "falseEmail",
                CategoryId = new List<int>() { 2, 3 }
            };

            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await requestService.Create(model, 1));
            Assert.AreEqual(GlobalExceptions.ConstructorDoesNotExistExceptionMessage, ex.Message);
        }


        [Test]
        public async Task EditRequestShouldReturnCorectResult()
        {
            await requestService.Edit(1, new AddRequestViewModel()
            {
                RoomsCount = 2,
                Area = 80,
                RequiredDate = "2022-12-15",
                Budget = 2300,
                CategoryId = new List<int>() { 2, 3 }
            });

            var dbRequest = await repo.GetByIdAsync<Request>(1);

            Assert.That(dbRequest.Area, Is.EqualTo(80));
        }


        [Test]
        public async Task EditRequestShouldThrowNullException()
        {
            var model = new AddRequestViewModel()
            {
                RoomsCount = 2,
                Area = 80,
                RequiredDate = "2022-12-15",
                Budget = 2300,
                CategoryId = new List<int>() { 2, 3 }
            };

            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await requestService.Edit(5, model));
            Assert.AreEqual(GlobalExceptions.RequestDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        public async Task EditRequestShouldChangeCategoriesCorrectly()
        {
            await requestService.Create(new AddRequestViewModel()
            {
                RoomsCount = 2,
                Area = 80,
                RequiredDate = "2022-12-15",
                Budget = 2300,
                ConstructorEmail = "constructor@gmail.com",
                CategoryId = new List<int>() { 2, 3 }
            }, 1);

            await requestService.Edit(4, new AddRequestViewModel()
            {
                RoomsCount = 4,
                Area = 80,
                RequiredDate = "2022-12-15",
                Budget = 2300,
                CategoryId = new List<int>() { 3,  4}
            });

            var dbRequestEdited = await repo.GetByIdAsync<Request>(4);
            var firstElementEdited = dbRequestEdited.RoomsTypes.First();

            Assert.That(dbRequestEdited.RoomsTypes.Count, Is.EqualTo(2));
            Assert.That(firstElementEdited.Id, Is.EqualTo(3));
            Assert.That(dbRequestEdited.RoomsCount, Is.EqualTo(4));
        }


        [Test]
        public async Task ExistRequestShouldReturnTrue()
        {
            var dbRequest = await requestService.Exists(1);

            Assert.That(dbRequest, Is.EqualTo(true));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task ExistRequestShouldReturnFalse(int id)
        {
            var dbRequest = await requestService.Exists(id);
            Assert.That(dbRequest, Is.EqualTo(false));
        }


        [Test]
        public async Task RequestByIdMethodShouldReturnCorectResult()
        {
            var request = await requestService.RequestById(1);
            var dbRequest = await repo.GetByIdAsync<Request>(1);

            Assert.That(dbRequest.Area, Is.EqualTo(request.Area));
            Assert.That(dbRequest.Constructor.User.Email, Is.EqualTo(request.ConstructorEmail));
            Assert.That(dbRequest.ClientId, Is.EqualTo(request.ClientId));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task RequestByIdMethodShouldThrowNullException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await requestService.RequestById(id));
            Assert.ThrowsAsync<NullReferenceException>(async () => await requestService.RequestById(id));
            Assert.AreEqual(GlobalExceptions.RequestDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        public async Task DeleteRequestShouldDisactivateRequestSuccessfully()
        {
            await requestService.Delete(1);
            var dbRequest = await repo.GetByIdAsync<Request>(1);

            Assert.IsNotNull(dbRequest);
            Assert.That(dbRequest.IsActive, Is.EqualTo(false));
        }


        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task DeleteRequestShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await requestService.Delete(id));
            Assert.AreEqual(GlobalExceptions.RequestDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(2)]
        public async Task DeleteRequestShouldThrowArgumentException(int id)
        {
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await requestService.Delete(id));
            Assert.AreEqual(GlobalExceptions.RequestAlreadyDeleted, ex.Message);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GetRequestStatusShouldReturnCorrectResult(int id)
        {
           var request =  await requestService.GetStatus(id);
            var dbRequest = await repo.GetByIdAsync<Request>(id);

            Assert.IsNotNull(dbRequest);
            Assert.That(dbRequest.Status, Is.EqualTo(request));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task GetRequestStatusShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await requestService.GetStatus(id));
            Assert.AreEqual(GlobalExceptions.RequestDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(1)]
        public async Task GetRequestDetailsShouldReturnCorrectResult(int id)
        {
            var request = await requestService.GetDetailsRequest(id);
            var dbRequest = await repo.GetByIdAsync<Request>(id);

            Assert.That(dbRequest.RoomsCount, Is.EqualTo(request.RoomsCount));
            Assert.That(dbRequest.RoomsTypes.Count, Is.EqualTo(request.RoomsTypes.ToList().Count));
            Assert.That(dbRequest.ClientId, Is.EqualTo(request.Client.ClientId));
            Assert.That(dbRequest.ConstructorId, Is.EqualTo(request.Constructor.ConstructorId));
        }


        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task GetRequestDetailsShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await requestService.GetDetailsRequest(id));
            Assert.AreEqual(GlobalExceptions.RequestDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(1)]
        public async Task RejectRequestShouldChangeStatusSuccessfully(int id)
        {
            await requestService.Reject(id);
            var dbRequest = await repo.GetByIdAsync<Request>(id);

            Assert.IsNotNull(dbRequest);
            Assert.That(dbRequest.Status, Is.EqualTo("Rejected"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(7)]
        public async Task RejectRequestShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await requestService.Reject(id));
            Assert.AreEqual(GlobalExceptions.RequestDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(3)]
        public async Task RejectRequestShouldThrowArgumentException(int id)
        {
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await requestService.Reject(id));
            Assert.AreEqual(GlobalExceptions.RequestAlreadyRejected, ex.Message);
        }

        [Test]
        [TestCase(1)]
        public async Task ConfirmRequestShouldChangeStatusSuccessfully(int id)
        {
            await requestService.Confirm(id);
            var dbRequest = await repo.GetByIdAsync<Request>(id);

            Assert.IsNotNull(dbRequest);
            Assert.That(dbRequest.Status, Is.EqualTo("Confirmed"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(7)]
        public async Task ConfirmRequestShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await requestService.Confirm(id));
            Assert.AreEqual(GlobalExceptions.RequestDoesNotExistExceptionMessage, ex.Message);
        }


        [Test]
        [TestCase(1)]
        public async Task ConfirmRequestShouldThrowArgumentException(int id)
        {
            await requestService.Confirm(id);
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await requestService.Confirm(id));
            Assert.AreEqual(GlobalExceptions.RequestAlreadyConfirmed, ex.Message);
        }

        [Test]
        [TestCase(1, "ClientTestId")]
        public async Task HasClientRequestShouldChangeStatusSuccessfully(int id, string clientId)
        {
           var hasclient =  await requestService.HasClient(id, clientId);

            Assert.That(hasclient, Is.EqualTo(true));
        }

        [Test]
        [TestCase(0, "ClientTestId")]
        [TestCase(-1, "ClientTestId")]
        [TestCase(2, "ClientTestId")]
        [TestCase(7, "ClientTestId")]
        [TestCase(null, null)]
        public async Task HasClientRequestShouldThrowNullReferenceException(int id, string clientId)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await requestService.HasClient(id, clientId));
            Assert.AreEqual(GlobalExceptions.RequestDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(1, null)]
        public async Task HasClientRequestShouldThrowNullReferenceExceptionForClient(int id, string clientId)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await requestService.HasClient(id, clientId));
            Assert.AreEqual(GlobalExceptions.ClientDoessNotExistsExceptionMessage, ex.Message);
        }


        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task GetReequestConstructorShouldReturnCorrectResult(int id)
        {
            var request = await requestService.GetRequestsConstructorId(id);
            var dbRequest = await repo.GetByIdAsync<Request>(id);

            Assert.That(request, Is.EqualTo(dbRequest.ConstructorId));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        [TestCase(7)]
        public async Task GetRequestConstructorShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await requestService.Reject(id));
            Assert.AreEqual(GlobalExceptions.RequestDoesNotExistExceptionMessage, ex.Message);
        }


        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task AllRequestsByClientIdShouldReturnCorrectCollection(int id)
        {
            var dbRequets = await repo.All<Request>()
                .Where(p => p.ClientId == id && p.IsActive && p.Constructor.User.IsActive == true && p.Client.User.IsActive == true)
                .OrderByDescending(r => r.Id)
                .Select(p => p.Id)
                .ToListAsync();

            var requestsByClientIdInfo = (List<RequestViewModel>)await requestService.AllRequestsByClientId(id);

            var requestsByClientId = requestsByClientIdInfo.Select(r => r.Id).ToList();

            Assert.AreEqual(dbRequets.Count, requestsByClientId.Count);
            Assert.AreEqual(dbRequets, requestsByClientId);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task AllRequestsByConstructorIdShouldReturnCorrectCollection(int id)
        {
            var dbRequets = await repo.All<Request>()
                .Where(r => r.IsActive == true && r.Status == "Waiting")
                .Where(r => r.ConstructorId == id && r.Constructor.User.IsActive == true && r.Client.User.IsActive == true)
                .OrderByDescending(r => r.Id)
                .Select(p => p.Id)
                .ToListAsync();

            var requestsByConstructorIdInfo = (List<RequestViewModel>)await requestService.AllRequestsForConstructorById(id);

            var requestsByConstructorId = requestsByConstructorIdInfo.Select(r => r.Id).ToList();

            Assert.AreEqual(dbRequets.Count, requestsByConstructorId.Count);
            Assert.AreEqual(dbRequets, requestsByConstructorId);
        }
    }
}
