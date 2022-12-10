using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Request;
using ArrnowConstruct.Extensions;
using Microsoft.AspNetCore.Mvc;
using ArrnowConstruct.Core.Constants;
using System.Globalization;

namespace ArrnowConstruct.Controllers
{
    public class RequestController : BaseController
    {
        private readonly IRequestService requestService;
        private readonly IClientService clientService;
        private readonly IConstructorService constructorService;
        private readonly ICategoryService categoryService;
        private readonly ISiteService siteService;

        public RequestController(
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
            if (model.CategoryId.Count == 0)
            {
                ModelState.AddModelError(nameof(model.RoomsCount), "You haven't selected any type of room!");
            }
            if (DateTime.Compare(DateTime.Parse(model.RequiredDate), DateTime.Now) < 0)
            {
                ModelState.AddModelError(nameof(model.RequiredDate), "The chosen date have already passed!");
            }
            if(await constructorService.ConstructorWithEmailExists(model.ConstructorEmail) == -1)
            {
                ModelState.AddModelError(nameof(model.ConstructorEmail), "A constructor with this email does not exists!");
            }

            if (!ModelState.IsValid)
            {
                model.RoomsTypes = await categoryService.AllCategories();

                return View(model);
            }

            int clientId = await clientService.GetClientId(User.Id());

            await requestService.Create(model, clientId);

            return RedirectToAction(nameof(Mine));
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
                return RedirectToAction("Mine", "Request");
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
            }
            if (model.CategoryId.Count > model.RoomsCount)
            {
                ModelState.AddModelError(nameof(model.RoomsCount), "The selected types of rooms were more than the rooms count!");
            }
            if (model.CategoryId.Count == 0)
            {
                ModelState.AddModelError(nameof(model.RoomsCount), "You haven't selected any type of room!");
            }
            if (DateTime.Compare(DateTime.Parse(model.RequiredDate), DateTime.Now) < 0)
            {
                ModelState.AddModelError(nameof(model.RequiredDate), "The chosen date have already passed!");
            }
            if ((await requestService.HasClient(model.Id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (!ModelState.IsValid)
            {
                model.RoomsTypes = await categoryService.AllCategories();

                return View(model);
            }

            await requestService.Edit(model.Id, model);

            return RedirectToAction(nameof(Mine));
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
                Client = request.Client,
                Constructor = request.Constructor
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
                Client = request.Client,
                Constructor = request.Constructor,
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

        [HttpGet]
        public async Task<IActionResult> Confirm(int id)
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
            var model = new RequestConfirmViewModel()
            {
                RequiredDate = request.RequiredDate
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Confirm(int id, RequestConfirmViewModel model)
        {
            var request = await requestService.GetDetailsRequest(id);

            if ((await requestService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Mine));
            }
            if ((await requestService.GetStatus(id) != "Waiting"))
            {
                return RedirectToPage(nameof(Mine));
            }
            if (model.Price > request.Budget)
            {
                ModelState.AddModelError(nameof(model.Price), "The price you chose should not be bigger than client's budget! Otherwise reject the request!");
            }
            if (DateTime.Compare(DateTime.Parse(model.FromDate), DateTime.Parse(model.RequiredDate)) < 0)
            {
                ModelState.AddModelError(nameof(model.FromDate), "The chosen date should be after the required one from the client!");
            }
            if (DateTime.Compare(DateTime.Parse(model.FromDate), DateTime.ParseExact(model.RequiredDate, "yyyy-MM-dd", CultureInfo.CurrentCulture)) > 0)
            {
                ModelState.AddModelError(nameof(model.ToDate), "The chosen date should be after the starting date!");
            }


            var fromDate = DateTime.ParseExact(model.FromDate, "yyyy-M-d", CultureInfo.CurrentCulture);
            var toDate = DateTime.ParseExact(model.ToDate, "yyyy-M-d", CultureInfo.CurrentCulture);


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await requestService.Confirm(id);
            await siteService.Create(request, model);

            return RedirectToAction("Mine", "Site");
        }
    }
}
