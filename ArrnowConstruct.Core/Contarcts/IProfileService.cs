using ArrnowConstruct.Core.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Contarcts
{
    public interface IProfileService
    {
        Task<ProfileViewModel> MyProfile(string userId);

        Task Edit(string userId, RegisterViewModel model);
    }
}
