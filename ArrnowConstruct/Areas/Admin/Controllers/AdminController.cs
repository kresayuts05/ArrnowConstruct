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
            var model = await postService.GetSixNewestPosts();

            return View("Index", model);
        }

        public async Task<IActionResult> All()
        {
            var model = await clientService.GetAllClients(this.User.Id());

            return View(model);
        }

        public async Task<IActionResult> Contacts()
        {
            var admin = await userService.GetAdministrator();

            return View(admin);
        }
    }
}
