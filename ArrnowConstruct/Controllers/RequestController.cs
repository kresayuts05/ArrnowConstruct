using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Request;
using ArrnowConstruct.Extensions;
using Microsoft.AspNetCore.Mvc;
using ArrnowConstruct.Core.Constants;

namespace ArrnowConstruct.Controllers
{
    public class RequestController : BaseController
    {
        private readonly IRequestService requestService;
        private readonly IClientService clientService;
        private readonly IConstructorService constructorService;
        private readonly ICategoryService categoryService;

        public RequestController(
            IRequestService _requestService,
            IClientService _clientService,
            IConstructorService _constructorService,
            ICategoryService _categoryService)
        {
            requestService = _requestService;
            clientService = _clientService;
            constructorService = _constructorService;
            categoryService = _categoryService;
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
            else if (model.CategoryId.Count == 0)
            {
                ModelState.AddModelError(nameof(model.RoomsCount), "You haven't selected any type of room!");
            }
            if (!ModelState.IsValid)
            {
                model.RoomsTypes = await categoryService.AllCategories();

                return View(model);
            }

            int clientId = await clientService.GetClientId(User.Id());

            await requestService.Create(model, clientId);

            return RedirectToAction("Index", "Home");
            //return RedirectToAction(nameof(Details), new { id });
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<RequestViewModel> myRequests = new List<RequestViewModel>();

            if (this.User.IsInRole(RoleConstants.Client))
            {
                int clientId = await clientService.GetClientId(userId);
               myRequests = await requestService.AllRequestsByClientId(clientId);
            }
            else if (this.User.IsInRole(RoleConstants.Constructor))
            {
                int constructorId = await constructorService.GetConstructorId(userId);
                myRequests = await requestService.AllRequestsForConstructorById(constructorId);
            }

            return View(myRequests);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await requestService.Exists(id)) == false)
            {
                return RedirectToAction("Index", "Home");
            }

            var request = await requestService.RequestById(id);
            var requestCurrCategories = await categoryService.CategoriesById(request.CategoryId);

            var model = new AddRequestViewModel()
            {
                Id = request.Id,
                RoomsCount = request.RoomsCount,
                Area = request.Area,
                RequiredDate = request.RequiredDate,
                Budget = request.Budget,
                ConstructorEmail = request.ConstructorEmail,
                CategoryId = request.RoomsTypes.Select(x => x.Id).ToList(),
                RoomsTypes = await categoryService.AllCategories(),
                IsActive = request.IsActive
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddRequestViewModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await requestService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Request does not exist");
                model.RoomsTypes = await categoryService.AllCategories();

                return View(model);
            }

            //if ((await houseService.HasAgentWithId(model.Id, User.Id())) == false)
            //{
            //    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            //}

            if (model.IsActive == false)
            {
                ModelState.AddModelError(nameof(model.Id), "Request does not exist");

                return RedirectToAction("Mine", "Request");
            }

            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Mine", "Request");
            }


            await requestService.Edit(model.Id, model);

            return RedirectToAction(nameof(Mine), new { model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await requestService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Mine));
            }

            if ((await requestService.GetStatus(id) != "Waiting"))
            {
                return RedirectToPage(nameof(Mine));
            }

            var request = await requestService.GetDetailsRequest(id);
            var model = new RequestViewModel()
            {
                ClientAddress = request.ClientAddress,
                ConstructorEmail = request.ConstructorEmail
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, RequestViewModel model)
        {
            if ((await requestService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Mine));
            }

            if ((await requestService.GetStatus(id) != "Waiting"))
            {
                return RedirectToPage(nameof(Mine));
            }

            await requestService.Delete(id);

            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> Reject(int id)
        {
            if ((await requestService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Mine));
            }

            if ((await requestService.GetStatus(id) != "Waiting"))
            {
                return RedirectToPage(nameof(Mine));
            }

            var request = await requestService.GetDetailsRequest(id);
            var model = new RequestViewModel()
            {
                ClientAddress = request.ClientAddress,
                ClientEmail = request.ClientEmail,
                RequiredDate = request.RequiredDate
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Reject(int id, RequestViewModel model)
        {
            if ((await requestService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Mine));
            }

            if ((await requestService.GetStatus(id) != "Waiting"))
            {
                return RedirectToPage(nameof(Mine));
            }

            await requestService.Reject(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
