using ArrnowConstruct.Core.Constants;
using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Home;
using ArrnowConstruct.Core.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArrnowConstruct.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;
        private readonly IConstructorService constructorService;
        private readonly IUserService userService;

        public HomeController(IPostService _postService,
            IConstructorService _constructorService,
            IUserService _userService)
        {
            postService = _postService;
            constructorService = _constructorService;
            userService = _userService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(RoleConstants.Administrator))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            var model = await postService.GetSixNewestPosts();

            return View(model);
        }

        public async Task<IActionResult> All()
        {
            var model = await constructorService.GetAllConstructors();

            return View(model);
        }

        public async Task<IActionResult> Contacts()
        {
            var admin = await userService.GetAdministrator();

            return View(admin);
        }
    }
}