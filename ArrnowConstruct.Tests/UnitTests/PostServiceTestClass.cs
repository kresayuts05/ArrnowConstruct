using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Exceptions;
using ArrnowConstruct.Core.Models.Post;
using ArrnowConstruct.Core.Services;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Tests.UnitTests
{
    [TestFixture]
    public class PostServiceTestClass : UnitTestsBase
    {
        private IRepository repo;
        private IPostService postService;
        private ISiteService siteService;
        private IConstructorService constructorService;

        [SetUp]
        public async Task Setup()
        {
            this.repo = new Repository(this.context);
            this.siteService = new SiteService(repo, null, null, null);
            this.constructorService = new ConstructorService(repo);
            this.postService = new PostService(repo, siteService, null, constructorService);
        }

        [Test]
        public async Task CreatePostShouldReturnCorectResult()
        {
            await postService.Create(new PostFormViewModel()
            {
                Description = "My description is very short, but meaningful 3",
                ShortContent = "The short content is even shorter 3",
                Title = "The best post 3",
                SiteId = 2,
                Images = new List<IFormFile>()
            }) ;

            var dbPost = await repo.GetByIdAsync<Post>(3);

            Assert.IsNotNull(dbPost);
            Assert.That(dbPost.Title, Is.EqualTo("The best post 3"));
            Assert.That(dbPost.IsActive, Is.EqualTo(true));
            Assert.That(dbPost.Image.Count, Is.EqualTo(0));
        }

        [Test]
        [TestCase(1)]
        public async Task PostDetailsByIdShouldReturnCorectResult(int id)
        {
            var post = await postService.PostDetailsById(id);
            var dbPost = await repo.GetByIdAsync<Post>(id);

            Assert.That(dbPost.CreatedOn.ToString("yyyy-M-d"), Is.EqualTo(post.CreatedOn));
            Assert.That(dbPost.ShortContent, Is.EqualTo(post.ShortContent));
            Assert.That(dbPost.Title, Is.EqualTo(post.Title));
            Assert.That(dbPost.SiteId, Is.EqualTo(post.Site.Id));
            Assert.That(post.Images.Count, Is.EqualTo(0));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task PostDetailsShouldThrowNullException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await postService.PostDetailsById(id));
            Assert.AreEqual(GlobalExceptions.PostDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(1)]
        public async Task ExistPostShouldReturnTrue(int id)
        {
            var dbPost = await postService.Exists(id);

            Assert.That(dbPost, Is.EqualTo(true));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task ExistPostShouldReturnFalse(int id)
        {
            var dbPost = await postService.Exists(id);
            Assert.That(dbPost, Is.EqualTo(false));
        }
    }
}
