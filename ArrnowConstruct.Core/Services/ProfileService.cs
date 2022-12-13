using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Exceptions;
using ArrnowConstruct.Core.Models.Profile;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRepository repo;
        private readonly IImageService imageService;
        private readonly IPostService postService;


        public ProfileService(
            IRepository _repo,
            IImageService _imageservice,
            IPostService _postService)
        {
            repo = _repo;
            imageService = _imageservice;
            postService = _postService;
        }

        public async Task<ProfileViewModel> MyProfile(string userId, bool isConstructor)
        {
            var user = await repo.GetByIdAsync<User>(userId);

            if (user == null)
            {
                throw new NullReferenceException(GlobalExceptions.UserDoesNotExistExceptionMessage);
            }
            var profile = new ProfileViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Country = user.Country,
                City = user.City,
                PhoneNumber = user.PhoneNumber,
                ProfilePictureUrl = user.ProfilePictureUrl,

            };

            if (isConstructor == true)
            {
                var posts = await postService.AllPostsIdByUserId(userId);

                var postImages = await repo.All<Image>()
                    .Where(i => posts.Contains(i.PostId))
                    .ToListAsync();

                profile.PostsCount = posts.Count();
                profile.Images = postImages.Select(i => i.UrlPath).ToList();
            }

            return profile;
        }

        public async Task Edit(string userId, EditViewModel model)
        {
            var user = await repo.GetByIdAsync<User>(userId);

            if (user == null)
            {
                throw new NullReferenceException(GlobalExceptions.UserDoesNotExistExceptionMessage);
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address;
            user.City = model.City;
            user.Country = model.Country;

            user.ProfilePictureUrl = await this.imageService.UploadImage(model.ProfilePicture, "images", user);

            await repo.SaveChangesAsync();
        }
    }
}
