using ArrnowConstruct.Core.Models.Category;
using ArrnowConstruct.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Contarcts
{
    public interface IRequestService
    {
        Task<int> ConstructorWithEmailExists(string email);

        Task Create(AddRequestViewModel model, int clientId);

        Task<IEnumerable<RequestViewModel>> AllRequestsByClientId(int id);

        //Task<RequestDetailsModel> HouseDetailsById(int id);

        //Task<bool> Exists(int id);

        //Task Edit(int requestId, RequestModel model);


        //Task<string> GetStatus(int requestId);

        //Task Delete(int requestId);

        //Task<bool> IsConfirmedByConstructor(int requestId, string constructorId);
    }
}
