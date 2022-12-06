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
    public class UserService : IUserService
    {

        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<User> GetUserById(string userId)
        {
            return await repo.GetByIdAsync<User>(userId);
        }
    }
}
