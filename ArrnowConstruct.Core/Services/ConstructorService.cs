using ArrnowConstruct.Core.Contarcts;
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
            var constructor = await repo.All<Constructor>(c => c.UserId == userId)
                .FirstOrDefaultAsync();

            return constructor != null;
        }

        public async Task<int> GetConstructorId(string userId)
        {
            return (await repo.AllReadonly<Constructor>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task<User> GetUserByConstructorId(int id)
        {
            return await repo.All<Constructor>()
                .Where(c => c.Id == id)
                .Select(c => c.User)
                .FirstAsync();
        }

        public async Task<int> ConstructorWithEmailExists(string email)
        {
            var user = await repo.AllReadonly<User>()
                .FirstOrDefaultAsync(u => u.Email == email);

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

            var user = await repo.GetByIdAsync<User>(userModel.UserId);

            return user.Email;
        }
    }
}
