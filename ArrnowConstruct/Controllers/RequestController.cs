using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Request;
using ArrnowConstruct.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Controllers
{
    public class RequestController : BaseController
    {
        private readonly IRequestService requestService;
        private readonly IClientService clientService;
        private readonly ICategoryService categoryService;

        public RequestController(
            IRequestService _requestService,
            IClientService _clientService)
        {
            requestService = _requestService;
            clientService = _clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddRequestViewModel()
            {
                RoomsTypes = await categoryService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRequestViewModel model)
        {

            if (model.CategoryId.Count > model.RoomsCount)
            {
                ModelState.AddModelError(nameof(model.RoomsCount), "The selected types of rooms were more than the rooms count!");
            }
            else if(model.CategoryId.Count == 0)
            {
                ModelState.AddModelError(nameof(model.RoomsCount), "You haven't selected any type of room!");
            }
            if (!ModelState.IsValid)
            {
                model.RoomsTypes = await categoryService.AllCategories();

                return View(model);
            }

            int clientId = await clientService.GetClientId(User.Id());

            int id = await requestService.Create(model, clientId);

            return RedirectToAction("Index", "Home");
            //return RedirectToAction(nameof(Details), new { id });
        }

    }
}
