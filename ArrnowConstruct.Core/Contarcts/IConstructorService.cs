using ArrnowConstruct.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Contarcts
{
    public interface IConstructorService
    {
        Task Create(string userId);

        Task<User> GetUserByConstructorId(int id);

        Task<bool> ExistsById(string userId);

        Task<int> GetConstructorId(string userId);

    }
}
