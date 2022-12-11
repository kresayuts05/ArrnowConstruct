using ArrnowConstruct.Core.Models.User;
using ArrnowConstruct.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Contarcts
{
    public interface IUserService
    {
        Task<UserModel> GetUserById(string userId);

        Task<UserModel> GetAdministrator();

        Task<IEnumerable<UserModel>> AllUsers(string id);

        Task Delete(string userId);
    }
}
