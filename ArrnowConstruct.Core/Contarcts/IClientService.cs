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

        //Task<bool> ExistsById(string userId);

        //Task<bool> UserWithPhoneNumberExists(string phoneNumber);

        //Task<bool> UserHasRents(string userId);

        Task<int> GetClientId(string userId);
    }
}
