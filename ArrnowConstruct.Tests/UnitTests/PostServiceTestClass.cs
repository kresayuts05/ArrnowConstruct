using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Exceptions;
using ArrnowConstruct.Core.Models.Post;
using ArrnowConstruct.Core.Services;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Http;
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
            this.siteService = new SiteService(repo, null);
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
            });

            var dbPost = await repo.GetByIdAsync<Post>(4);

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


        [Test]
        public async Task EditPostShouldReturnCorectResult()
        {
            await postService.Edit(1, new PostFormViewModel()
            {
                Description = "This descriptin is edited",
                ShortContent = "The short content is edited",
                Title = "This title is edited",
                SiteId = 2,
                Images = new List<IFormFile>()
            });

            var dbPost = await repo.GetByIdAsync<Post>(1);

            Assert.That(dbPost.Description, Is.EqualTo("This descriptin is edited"));
            Assert.That(dbPost.ShortContent, Is.EqualTo("The short content is edited"));
            Assert.That(dbPost.Title, Is.EqualTo("This title is edited"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task EditPostShouldThrowRefferenceNullException(int id)
        {
            var model = new PostFormViewModel()
            {
                Description = "This descriptin is edited wrongly",
                ShortContent = "The short content is edited wrongly",
                Title = "This title is edited wrongly",
                SiteId = 2,
                Images = new List<IFormFile>()
            };

            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await postService.Edit(id, model));
            Assert.AreEqual(GlobalExceptions.PostDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(3)]
        public async Task EditPostShouldThrowArgumentException(int id)
        {
            var model = new PostFormViewModel()
            {
                Description = "This descriptin is edited wrongly",
                ShortContent = "The short content is edited wrongly",
                Title = "This title is edited wrongly",
                SiteId = 2,
                Images = new List<IFormFile>()
            };

            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await postService.Edit(id, model));
            Assert.AreEqual(GlobalExceptions.SiteDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        public async Task DeletePostShouldDisactivatePostSuccessfully()
        {
            await postService.Delete(1);
            var dbPost = await repo.GetByIdAsync<Post>(1);

            Assert.IsNotNull(dbPost);
            Assert.That(dbPost.IsActive, Is.EqualTo(false));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(null)]
        public async Task DeletePostShouldThrowNullReferenceException(int id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await postService.Delete(id));
            Assert.AreEqual(GlobalExceptions.PostDoesNotExistExceptionMessage, ex.Message);
        }

        [Test]
        [TestCase(2)]
        public async Task DeletePostShouldThrowArgumentException(int id)
        {
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await postService.Delete(id));
            Assert.AreEqual(GlobalExceptions.PostIsAlreadyDeleted, ex.Message);
        }

        [Test]
        [TestCase(1)]
        [TestCase(null)]
        public async Task AllPostsByConstructorShouldReturnCorrectCollection(int id)
        {
            var dbPosts = await repo.All<Post>()
                .Where(p => p.Site.ConstructorId == id)
                .ToListAsync();

            List<PostViewModel> postsByCostructor = (List<PostViewModel>)await postService.AllPostsByConstructor(id);

            for (int i = 0; i < postsByCostructor.Count; i++)
            {
                Assert.AreEqual(dbPosts[i].Id, postsByCostructor[i].Id);
            }
        }


        [Test]
        [TestCase("ConstructorTestId")]
        public async Task AllPostsByUserIdShouldReturnCorrectCollection(string id)
        {
            var dbPosts = await repo.All<Post>()
                .Where(p => p.Site.Constructor.UserId == id && p.IsActive)
                .Select(p => p.Id)
                .ToListAsync();

            var postsByUser = await postService.AllPostsIdByUserId(id);

            Assert.AreEqual(dbPosts.Count, postsByUser.Count);
            Assert.AreEqual(dbPosts, postsByUser);
        }


        [Test]
        [TestCase("ConstructorTestIdDisactivaated")]
        [TestCase("something not true")]
        [TestCase("")]
        [TestCase(null)]
        public async Task AllPostsByUserIdShouldThrowNullReferenceException(string id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await postService.AllPostsIdByUserId(id));
            Assert.AreEqual(GlobalExceptions.ConstructorDoesNotExistExceptionMessage, ex.Message);
        }


        [Test]
        public async Task GetSixNewestPostsShouldReturnCorrectCollection()
        {
            var dbPosts = await repo.All<Post>()
                .Where(p => p.Site.Constructor.User.IsActive == true && p.IsActive == true)
                .Select(p => p.Id)
                .ToListAsync();

            var sixPostsInfo = await postService.GetSixNewestPosts();
            var sixPosts = sixPostsInfo.Select(p => p.Id).ToList();

            Assert.AreEqual(dbPosts.Count, sixPosts.Count);
            Assert.AreEqual(dbPosts, sixPosts);
        }
    }
}
