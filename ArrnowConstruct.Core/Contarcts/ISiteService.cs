using ArrnowConstruct.Core.Models.Request;
using ArrnowConstruct.Core.Models.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Contarcts
{
    public interface ISiteService
    {
        Task Create(RequestViewModel request, RequestConfirmViewModel model);

        Task<IEnumerable<SiteViewModel>> AllSitesByConstructorId(int id);

        Task Finish(int siteId, SiteViewModel model);

        Task<string> GetStatus(int siteId);

        Task<SiteViewModel> SiteById(int id);

        Task<bool> Exists(int id);

        Task Delete(int id);
    }
}
