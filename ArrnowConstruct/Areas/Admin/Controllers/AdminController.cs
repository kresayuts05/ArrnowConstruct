using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IPostService postService;
        private readonly IConstructorService constructorService;
        private readonly IUserService userService;
        private readonly IClientService clientService;

        public AdminController(IPostService _postService,
            IConstructorService _constructorService,
             IUserService _userService,
            IClientService _clientService)
        {
            postService = _postService;
            constructorService = _constructorService;
            userService = _userService;
            clientService = _clientService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Contacts()
        {
            try
            {
                var admin = await userService.GetAdministrator();
                return View(admin);
            }
            catch (NullReferenceException ex)
            {
                TempData["message"] = ex.Message;

                return this.RedirectToAction("Index", "Home");
            }           
        }
    }
}
