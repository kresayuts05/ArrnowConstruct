using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Contarcts
{
    public interface IImageService
    {
        Task<Image> UploadImage(IFormFile imageFile, string nameFolder, int postId);

        Task<string> UploadImage(IFormFile imageFile, string nameFolder, User user);
    }
}
