using ArrnowConstruct.Core.Models.User;
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
        Task Create(string userId, decimal salary);

        //Task<User> GetUserByConstructorId(int id);

        Task<bool> ExistsById(string userId);

        Task<int> GetConstructorId(string userId);

        Task DisactivateConstructor(int id);

        Task<string> GetConstructorEmail(int constructorId);

        Task<int> ConstructorWithEmailExists(string email);

        Task<IEnumerable<ConstructorModel>> GetAllConstructors();
    }
}
