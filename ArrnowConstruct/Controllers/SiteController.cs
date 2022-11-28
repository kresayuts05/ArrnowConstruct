using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Site;
using ArrnowConstruct.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Controllers
{
    public class SiteController : BaseController
    {
        private readonly IRequestService requestService;
        private readonly IClientService clientService;
        private readonly IConstructorService constructorService;
        private readonly ICategoryService categoryService;
        private readonly ISiteService siteService;

        public SiteController(
           IRequestService _requestService,
           IClientService _clientService,
           IConstructorService _constructorService,
           ICategoryService _categoryService,
           ISiteService _siteService)
        {
            requestService = _requestService;
            clientService = _clientService;
            constructorService = _constructorService;
            categoryService = _categoryService;
            siteService = _siteService;
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();

            int constructorId = await constructorService.GetConstructorId(userId);
            IEnumerable<SiteViewModel> mySites = await siteService.AllSitesByConstructorId(constructorId);

            return View(mySites);
        }

        [HttpGet]
        public async Task<IActionResult> Finish(int id)
        {
            if ((await siteService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Mine));
            }

            if ((await siteService.GetStatus(id) != "In Process"))
            {
                return RedirectToPage(nameof(Mine));
            }

            var site = await siteService.SiteById(id);
            var model = new SiteViewModel()
            {
                Client = site.Client,
                Constructor = site.Constructor
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Finish(int id, SiteViewModel model)
        {
            if ((await requestService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Mine));
            }

            if ((await requestService.GetStatus(id) != "Waiting"))
            {
                return RedirectToPage(nameof(Mine));
            }

            await siteService.Finish(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
