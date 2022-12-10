using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository repo;

        public AdminService(IRepository _repo)
        {
            repo = _repo;
        }


        public async Task DisactivateClient(int id)
        {
           var client =  await repo.GetByIdAsync<Client>(id);

            client.IsActive = false;
            await repo.SaveChangesAsync();
        }
    }
}
