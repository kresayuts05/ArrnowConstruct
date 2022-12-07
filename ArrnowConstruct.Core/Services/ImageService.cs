using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary cloudinary;
        private readonly IRepository repo;

        public ImageService(
            Cloudinary cloudinary,
            IRepository _repo)
        {
            this.cloudinary = cloudinary;
            repo = _repo;
        }

        public async Task<Image> UploadImage(IFormFile imageFile, string nameFolder, int postId)
        {
            using var stream = imageFile.OpenReadStream();
            var image = new Image();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(image.Id.ToString(), stream),
                Folder = nameFolder,
            };

            var result = await this.cloudinary.UploadAsync(uploadParams);

            if (result.Error != null)
            {
                throw new InvalidOperationException(result.Error.Message);
            }

            image.UrlPath = result.Url.ToString();
            image.PostId = postId;
            image.IsActive = true;

            await this.repo.AddAsync(image);
            await this.repo.SaveChangesAsync();

            return image;
        }

        public async Task<string> UploadImage(IFormFile imageFile, string nameFolder, User user)
        {
            using var stream = imageFile.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(user.Id, stream),
                Folder = nameFolder,
            };

            var result = await this.cloudinary.UploadAsync(uploadParams);

            if (result.Error != null)
            {
                throw new InvalidOperationException(result.Error.Message);
            }

             user.ProfilePictureUrl = result.Url.ToString();

            this.repo.Update(user);
            await this.repo.SaveChangesAsync();

            return user.ProfilePictureUrl;
        }
    }
}
