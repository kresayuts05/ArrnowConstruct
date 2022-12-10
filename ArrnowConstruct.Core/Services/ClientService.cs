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
    public class ClientService : IClientService
    {
        private readonly IRepository repo;

        public ClientService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task Create(string userId)
        {
            var client = new Client()
            {
                UserId = userId,
            };

            await repo.AddAsync(client);
            await repo.SaveChangesAsync();
        }

        public async Task<List<UserModel>> GetAllClients(string adminId)
        {
            return await repo.All<Client>()
               .Where(c => c.User.Id != adminId && c.IsActive == true)
               .Select(c => new UserModel()
               {
                   Id = c.User.Id,
                   ProfilePictureUrl = c.User.ProfilePictureUrl,
                   Phone = c.User.PhoneNumber,
                   Address = c.User.Address,
                   City = c.User.City,
                   Country = c.User.Country,
                   Email = c.User.Email,
                   FirstName = c.User.FirstName,
                   LastName = c.User.LastName
               })
               .ToListAsync();
        }

        public async Task<int> GetClientId(string userId)
        {
            return (await repo.AllReadonly<Client>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task<User> GetUserByClientId(int id)
        {
            return await repo.All<Client>()
                .Where(c => c.Id == id)
                .Select(c => c.User)
                .FirstAsync();
        }

        public async Task DisactivateClient(int id)
        {
            var client = await repo.GetByIdAsync<Client>(id);

            client.IsActive = false;
            await repo.SaveChangesAsync();
        }
    }
}
