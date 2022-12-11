using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Site;
using ArrnowConstruct.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Controllers
{
    public class SiteController : BaseController
    {
        private readonly IRequestService requestService;
        private readonly IConstructorService constructorService;
        private readonly ISiteService siteService;

        public SiteController(
           IRequestService _requestService,
           IConstructorService _constructorService,
           ISiteService _siteService)
        {
            requestService = _requestService;
            constructorService = _constructorService;
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

            if ((await siteService.GetStatus(id) != "InProcess"))
            {
                return RedirectToPage(nameof(Mine));
            }

            var site = await siteService.SiteById(id);
            var model = new SiteViewModel()
            {
                FromDate = site.FromDate,
                Client = site.Client,
                Constructor = site.Constructor
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Finish(int id, SiteViewModel model)
        {
            if ((await siteService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Mine));
            }

            if ((await siteService.GetStatus(id) != "InProcess"))
            {
                return RedirectToPage(nameof(Mine));
            }

            if (DateTime.Compare(DateTime.Parse(model.FromDate), DateTime.Parse(model.ToDate)) > 0)
            {
                ModelState.AddModelError(nameof(model.ToDate), "The chosen date should be after the starting date of the site!");
                return View(model);
            }

            await siteService.Finish(id, model);

            return RedirectToAction(nameof(Mine));
        }
    }
}
