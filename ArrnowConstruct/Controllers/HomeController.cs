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

        public HomeController(IPostService _postService)
        {
            postService = _postService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await postService.GetFiveNewestPosts();


            return View(model);
        }
    }
}