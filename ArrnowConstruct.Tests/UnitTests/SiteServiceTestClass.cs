using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Exceptions;
using ArrnowConstruct.Core.Models.Request;
using ArrnowConstruct.Core.Models.Site;
using ArrnowConstruct.Core.Models.User;
using ArrnowConstruct.Core.Services;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using ArrnowConstruct.Infrastructure.Data.Entities.Enums;
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
    public class SiteServiceTestClass : UnitTestsBase
    {
        private IRepository repo;
        private ICategoryService categoryService;
        private ISiteService siteService;

        [SetUp]
        public async Task Setup()
        {
            this.repo = new Repository(this.context);
            this.categoryService = new CategoryService(repo);
            this.siteService = new SiteService(repo, categoryService);
        }


        [Test]
        public async Task CreateSiteShouldReturnCorrectResult()
        {
            var requestModel = new RequestViewModel()
            {
                RoomsCount = 2,
                Area = 80,
                Client = new ClientModel()
                {
                    ClientId = 1
                },
                Constructor = new ConstructorModel()
                {
                    ConstructorId = 1
                },
                CategoryId = new List<int>() { 2, 3 }
            };

            var confirmModel = new RequestConfirmViewModel()
            {
                FromDate = "2022-12-01",
                ToDate = "2022-12-11",
                Price = 1000
            };

            await siteService.Create(requestModel, confirmModel);

            var dbSite = await repo.GetByIdAsync<Site>(4);

            Assert.IsNotNull(dbSite);
            Assert.That(dbSite.Area, Is.EqualTo(80));
        }


        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task GetSiteStatusShouldReturnCorrectResult(int id)
        {
            var site = await siteService.GetStatus(id);
            var dbsite = await repo.GetByIdAsync<Site>(id);

            Assert.IsNotNull(dbsite);
            Assert.That(dbsite.Status, Is.EqualTo(site));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task GetSiteStatusShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await siteService.GetStatus(id));
            Assert.AreEqual(GlobalExceptions.SiteDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        public async Task SiteByIdMethodShouldReturnCorectResult()
        {
            var site = await siteService.SiteById(1);
            var dbSite = await repo.GetByIdAsync<Site>(1);

            Assert.That(dbSite.Area, Is.EqualTo(site.Area));
            Assert.That(dbSite.FromDate.ToString("yyyy-M-d"), Is.EqualTo(site.FromDate));
            Assert.That(dbSite.Constructor.User.Id, Is.EqualTo(site.Constructor.User.Id));
            Assert.That(dbSite.Client.User.Email, Is.EqualTo(site.Client.User.Email));
            Assert.That(dbSite.Status, Is.EqualTo(site.Status));
            Assert.That(dbSite.RoomsTypes.Count, Is.EqualTo(site.RoomsTypes.Count));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task SiteByIdMethodShouldThrowNullException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await siteService.SiteById(id));
            Assert.AreEqual(GlobalExceptions.SiteDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(1)]
        public async Task ConfirmRequestShouldChangeStatusSuccessfully(int id)
        {
            var model = new SiteViewModel()
            {
                ToDate = "2022-12-20"
            };

            await siteService.Finish(id, model);
            var dbSite = await repo.GetByIdAsync<Site>(id);

            Assert.IsNotNull(dbSite);
            Assert.That(dbSite.Status, Is.EqualTo("Finished"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task ConfirmRequestShouldThrowNullReferenceException(int id)
        {
            var model = new SiteViewModel()
            {
                ToDate = "2022-12-20"
            };

            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await siteService.Finish(id, model));
            Assert.AreEqual(GlobalExceptions.SiteDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public async Task ConfirmRequestShouldThrowArgumentException(int id)
        {
            var model = new SiteViewModel()
            {
                ToDate = "2022-12-20"
            };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await siteService.Finish(id, model));
            Assert.AreEqual(GlobalExceptions.SiteCannotBeFinished, ex.Message);
        }


        [Test]
        public async Task DeleteSiteShouldDisactivateRequestSuccessfully()
        {
            await siteService.Delete(1);
            var dbSite = await repo.GetByIdAsync<Site>(1);

            Assert.IsNotNull(dbSite);
            Assert.That(dbSite.Status, Is.EqualTo("Disactivated"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task DeleteSiteShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await siteService.Delete(id));
            Assert.AreEqual(GlobalExceptions.SiteDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(3)]
        public async Task DeleteSiteShouldThrowArgumentException(int id)
        {
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await siteService.Delete(id));
            Assert.AreEqual(GlobalExceptions.SiteIsAlreadyDisactivated, ex.Message);
        }


        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task ExistSiteShouldReturnTrue(int id)
        {
            var dbSite = await siteService.Exists(id);

            Assert.That(dbSite, Is.EqualTo(true));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task ExistSiteShouldReturnFalse(int id)
        {
            var dbSite = await siteService.Exists(id);
            Assert.That(dbSite, Is.EqualTo(false));
        }


        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task AllSitesByConstructorIdShouldReturnCorrectCollection(int id)
        {
            var dbSites = await repo.All<Site>()
               .Where(s => s.ConstructorId == id && s.Status != SiteStatusEnum.Disactivated.ToString())
                .OrderByDescending(s => s.Id)
                .Select(p => p.Id)
                .ToListAsync();

            var sitesByConstructorIdInfo = (List<SiteViewModel>)await siteService.AllSitesByConstructorId(id);

            var sitesByConstructorId = sitesByConstructorIdInfo.Select(r => r.Id).ToList();

            Assert.AreEqual(dbSites.Count, sitesByConstructorId.Count);
            Assert.AreEqual(dbSites, sitesByConstructorId);
        }


    }
}
