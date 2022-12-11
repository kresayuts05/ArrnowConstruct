using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.User;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Constants;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Services
{
    public class UserService : IUserService
    {

        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<UserModel> GetUserById(string userId)
        {
            var user = await repo.GetByIdAsync<User>(userId);

            //if (!user.IsActive)
            //{
            //    throw new ArgumentException(GlobalExceptions.UserNotHasPermission);
            //}

            var userModel = new UserModel()
            {
                Id = user.Id,
                ProfilePictureUrl = user.ProfilePictureUrl,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.PhoneNumber,
            };

            return userModel;
        }

        public async Task<UserModel> GetAdministrator()
        {
            return await repo.All<User>()
                .Where(u => u.Id == AdministartorConstant.Id)
                .Select(user => new UserModel()
                {
                    Id = user.Id,
                    Address = user.Address,
                    City = user.City,
                    Country = user.Country,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.PhoneNumber,
                    ProfilePictureUrl = user.ProfilePictureUrl,
                })
                .FirstAsync();

        }

        public async Task<IEnumerable<UserModel>> AllUsers()
        {
            return await repo.All<User>()
                .Where(u => u.IsActive == true)
                .Select(user => new UserModel()
                {
                    Id = user.Id,
                    Address = user.Address,
                    City = user.City,
                    Country = user.Country,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.PhoneNumber,
                    ProfilePictureUrl = user.ProfilePictureUrl
                })
                .ToListAsync();
        }

        public async Task Delete(string userId)
        {
            var user = await repo.GetByIdAsync<User>(userId);

            user.IsActive = false;

          await  repo.SaveChangesAsync();
        }
    }
}
