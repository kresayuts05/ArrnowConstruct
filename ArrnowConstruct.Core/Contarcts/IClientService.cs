using ArrnowConstruct.Core.Models.User;
using ArrnowConstruct.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Contarcts
{
    public interface IClientService
    {
        Task Create(string userId);

        Task<User> GetUserByClientId(int id);

        //Task<bool> ExistsById(string userId);

        Task<int> GetClientId(string userId);

        Task<List<UserModel>> GetAllClients(string adminId);

        Task DisactivateClient(int id);
    }
}
