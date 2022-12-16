using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Exceptions;
using ArrnowConstruct.Core.Models.User;
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
    public class ConstructorService : IConstructorService
    {

        private readonly IRepository repo;

        public ConstructorService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task Create(string userId, decimal minimumSalary)
        {
            var constructor = new Constructor()
            {
                UserId = userId,
                Salary= minimumSalary
            };

            await repo.AddAsync(constructor);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            var constructor = await repo.All<Constructor>(c => c.UserId == userId && c.User.IsActive == true)
                .FirstOrDefaultAsync();

            return constructor != null;
        }

        public async Task<int> GetConstructorId(string userId)
        {
            var constructor = await repo.AllReadonly<Constructor>()
                .FirstOrDefaultAsync(a => a.UserId == userId && a.User.IsActive == true);

            if(constructor == null)
            {
                throw new NullReferenceException(GlobalExceptions.ConstructorDoesNotExistExceptionMessage);
            }

            return constructor.Id;
        }

        public async Task<int> ConstructorWithEmailExists(string email)
        {
            var user = await repo.AllReadonly<User>()
                .FirstOrDefaultAsync(u => u.Email == email && u.IsActive == true);

            if (user != null)
            {
                Constructor constructor = await repo.All<Constructor>()
                .FirstOrDefaultAsync(c => c.UserId == user.Id);

                if (constructor != null)
                {
                    return constructor.Id;
                }
            }

            return -1;
        }

        public async Task<IEnumerable<ConstructorModel>> GetAllConstructors()
        {
            return await repo.All<Constructor>()
                .Where(c => c.User.IsActive == true)
                .Select(c => new ConstructorModel()
                {
                    ConstructorId = c.Id,
                    MinimumSalary = c.Salary,
                    User = new UserModel()
                    {
                        Id = c.User.Id,
                        ProfilePictureUrl = c.User.ProfilePictureUrl,
                        Address = c.User.Address,
                        City = c.User.City,
                        Country = c.User.Country,
                        Email = c.User.Email,
                        FirstName = c.User.FirstName,
                        LastName = c.User.LastName,
                        Phone = c.User.PhoneNumber
                    }
                }).ToListAsync();
        }

        public async Task<string> GetConstructorEmail(int constructorId)
        {
            var userModel = await repo.GetByIdAsync<Constructor>(constructorId);

            if (userModel == null || userModel.User.IsActive == false)
            {
                throw new NullReferenceException(GlobalExceptions.ConstructorDoesNotExistExceptionMessage);
            }

            var user = await repo.GetByIdAsync<User>(userModel.UserId);

            return user.Email;
        }


        public async Task DisactivateConstructor(int id)
        {
            var constructor = await repo.GetByIdAsync<Constructor>(id);

            if (constructor == null || constructor.User.IsActive == false)
            {
                throw new NullReferenceException(GlobalExceptions.ConstructorDoesNotExistExceptionMessage);
            }

            constructor.IsActive = false;
            await repo.SaveChangesAsync();
        }
    }
}
