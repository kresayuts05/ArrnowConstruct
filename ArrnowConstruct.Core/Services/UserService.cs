﻿using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Exceptions;
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

            if (user == null || user.IsActive == false)
            {
                throw new NullReferenceException(GlobalExceptions.UserDoesNotExistExceptionMessage);
            }

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
            var admin =  await repo.All<User>()
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
                .FirstOrDefaultAsync();

            if(admin == null)
            {
                throw new NullReferenceException(GlobalExceptions.AdministratorDoesNotExistExceptionMessage);
            }

            return admin;
        }

        public async Task<IEnumerable<UserModel>> AllUsers(string id)
        {
            return await repo.All<User>()
                .Where(u => u.IsActive == true && u.Id != id)
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

            if (user == null || user.IsActive == false)
            {
                throw new NullReferenceException(GlobalExceptions.UserDoesNotExistExceptionMessage);
            }

            user.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> UserByEmailExists(string email)
        {
            var user = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.Email == email && u.IsActive == true);

            return user != null;
        }
    }
}
