using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Post;
using ArrnowConstruct.Core.Models.Site;
using ArrnowConstruct.Core.Models.User;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace ArrnowConstruct.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository repo;
        private readonly ISiteService siteService;
        private readonly IImageService imageService;
        private readonly IConstructorService constructorService;

        public PostService(
            IRepository _repo,
            ISiteService _siteService,
            IImageService _imageservice,
            IConstructorService _constructorService)
        {
            repo = _repo;
            siteService = _siteService;
            imageService = _imageservice;
            constructorService = _constructorService;
        }

        public async Task Create(PostFormViewModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                CreatedOn = DateTime.Now,
                Description = model.Description,
                ShortContent = model.ShortContent,
                IsActive = true,
                SiteId = model.Id
            };

            await repo.AddAsync(post);
            await repo.SaveChangesAsync();

            foreach (var imageInfo in model.Images)
            {
                var image = await this.imageService.UploadImage(imageInfo, "images", post.Id);
                post.Image.Add(image);
            }
        }

        public async Task<IEnumerable<PostViewModel>> AllPostsByConstructor(int id)
        {
            var posts = await repo.All<Post>()
                 .Where(p => p.Site.ConstructorId == id && p.IsActive == true && p.Site.Constructor.IsActive == true)
                  .OrderByDescending(p => p.Id)
                 .Select(p => new PostViewModel
                 {
                     Id = p.Id,
                     CreatedOn = p.CreatedOn.ToString("yyyy-M-d"),
                     Description = p.Description,
                     ShortContent = p.ShortContent,
                     Title = p.Title,
                     Likes = p.Likes,
                     Images = p.Image.Where(i => i.IsActive == true).Select(i => i.UrlPath).ToList(),
                     Site = new SiteViewModel()
                     {
                         Id = p.Site.Id,
                         Constructor = new ConstructorModel()
                         {
                             ConstructorId = p.Site.ConstructorId
                         }
                     }
                 })
                 .ToListAsync();

            foreach (var post in posts)
            {
                var site = await siteService.SiteById(post.Site.Id);
                post.Site = site;
            }

            return posts;
        }

        public async Task<PostViewModel> PostDetailsById(int id)
        {
            var post = await repo.AllReadonly<Post>()
                    .Where(p => p.IsActive)
                    .Where(p => p.Id == id && p.Site.Constructor.IsActive == true)
                    .Select(p => new PostViewModel()
                    {
                        Id = p.Id,
                        CreatedOn = p.CreatedOn.ToString("yyyy-M-d"),
                        Description = p.Description,
                        ShortContent = p.ShortContent,
                        Title = p.Title,
                        Likes = p.Likes,
                        Images = p.Image.Where(i => i.IsActive == true).Select(i => i.UrlPath).ToList(),
                        Site = new SiteViewModel() { Id = p.Site.Id }
                    })
                    .FirstAsync();

            post.Site = await siteService.SiteById(post.Site.Id);
            return post;
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Post>()
                .AnyAsync(p => p.Id == id && p.IsActive == true && p.Site.Constructor.IsActive == true);
        }

        public async Task Edit(int postId, PostFormViewModel model)
        {
            var post = await repo.GetByIdAsync<Post>(postId);

            var images = await repo.All<Image>()
                .Where(i => i.PostId == postId && i.IsActive == true)
                .ToListAsync();

            foreach (var image in images)
            {
                image.IsActive = false;
            }

            post.Title = model.Title;
            post.UpdatedOn = DateTime.Now;
            post.Description = model.Description;
            post.ShortContent = model.ShortContent;

            await repo.SaveChangesAsync();

            post.Image = new List<Image>();
            foreach (var imageInfo in model.Images)
            {
                var image = await this.imageService.UploadImage(imageInfo, "images", post.Id);
                post.Image.Add(image);
            }

            await repo.SaveChangesAsync();
        }

        public async Task Delete(int postId)
        {
            var post = await repo.GetByIdAsync<Post>(postId);
            post.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task<List<int>> AllPostsIdByUserId(string userId)
        {
            var constructorId = await constructorService.GetConstructorId(userId);

            return await repo.All<Post>()
                .Where(p => p.Site.ConstructorId == constructorId && p.IsActive == true && p.Site.Constructor.IsActive == true)
                .OrderByDescending(p => p.Id)
                .Select(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostViewModel>> GetSixNewestPosts()
        {
            return await repo.All<Post>()
                .Where(p => p.IsActive == true && p.Site.Constructor.IsActive == true)
                .OrderByDescending(p => p.CreatedOn)
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    CreatedOn = p.CreatedOn.ToString("yyyy-M-d"),
                    Description = p.Description,
                    ShortContent = p.ShortContent,
                    Title = p.Title,
                    Likes = p.Likes,
                    Images = p.Image.Where(i => i.IsActive == true).Select(i => i.UrlPath).ToList(),
                    Site = new SiteViewModel()
                    {
                        Id = p.Site.Id,
                        Constructor = new ConstructorModel()
                        {
                            User = new UserModel()
                            {
                                Email = p.Site.Constructor.User.Email,
                            }
                        }
                    }
                })
                .Take(6)
                .ToListAsync();
        }
    }
}

