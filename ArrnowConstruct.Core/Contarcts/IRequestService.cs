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

        Task Create(AddRequestViewModel model, int clientId);

        Task<IEnumerable<RequestViewModel>> AllRequestsByClientId(int id);

        Task<IEnumerable<RequestViewModel>> AllRequestsForConstructorById(int id);

        Task<AddRequestViewModel> RequestById(int id);

        Task<bool> Exists(int id);

        Task Edit(int requestId, AddRequestViewModel model);

        Task<string> GetStatus(int requestId);

        Task Delete(int requestId);

        Task<RequestViewModel> GetDetailsRequest(int id);

        Task Reject(int requestId);

        Task Confirm(int requestId);
    }
}
