using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Home;
using ArrnowConstruct.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArrnowConstruct.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;
        private readonly IConstructorService constructorService;

        public HomeController(IPostService _postService,
            IConstructorService _constructorService)
        {
            postService = _postService;
            constructorService = _constructorService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await postService.GetSixNewestPosts();

            return View(model);
        }

        public async Task<IActionResult> All()
        {
            var model = await constructorService.GetAllConstructors();

            return View(model);
        }
    }
}