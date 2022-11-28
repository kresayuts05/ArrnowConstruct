using ArrnowConstruct.Core.Contarcts;
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

        public async Task Create(string userId)
        {
            var constructor = new Constructor()
            {
                UserId = userId,
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
    }
}
