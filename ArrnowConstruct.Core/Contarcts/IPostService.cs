using ArrnowConstruct.Core.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Contarcts
{
    public interface IPostService
    {
        //Task<int> ConstructorWithEmailExists(string email);

      Task Create(int siteId, PostFormViewModel model);

        //Task<IEnumerable<RequestViewModel>> AllRequestsByClientId(int id);

        //Task<AddRequestViewModel> RequestById(int id);

        //Task<bool> Exists(int id);

        //Task Edit(int requestId, AddRequestViewModel model);


        //Task<string> GetStatus(int requestId);

        //Task Delete(int requestId);

        //Task<RequestViewModel> GetDetailsRequest(int id);
    }
}
