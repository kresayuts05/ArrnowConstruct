using ArrnowConstruct.Core.Constants;
using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Post;
using ArrnowConstruct.Core.Models.Site;
using ArrnowConstruct.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;

namespace ArrnowConstruct.Controllers
{
    [Authorize(Roles = RoleConstants.Constructor)]
    public class PostController : BaseController
    {
        private readonly IRequestService requestService;
        private readonly IClientService clientService;
        private readonly IConstructorService constructorService;
        private readonly ICategoryService categoryService;
        private readonly ISiteService siteService;
        private readonly IPostService postService;

        public PostController(
            IRequestService _requestService,
            IClientService _clientService,
            IConstructorService _constructorService,
            ICategoryService _categoryService,
            ISiteService _siteService,
            IPostService _postService)
        {
            requestService = _requestService;
            clientService = _clientService;
            constructorService = _constructorService;
            categoryService = _categoryService;
            siteService = _siteService;
            postService = _postService;
        }

        [HttpGet]
        public IActionResult Create(int siteId)
        {
            var model = new PostFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostFormViewModel model)
        {
            await postService.Create(model);

            return RedirectToAction("Index", "Home");
            //return RedirectToAction(nameof(Details), new { id });
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            var constructorId = await constructorService.GetConstructorId(userId);

            IEnumerable<PostViewModel> myPosts = await postService.AllPostsByConstructor(constructorId);

            return View(myPosts);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
        //    if ((await postService.Exists(id)) == false)
        //    {
        //        //return RedirectToAction(nameof(All));
        //    }

            var model = await postService.PostDetailsById(id);

            return View(model);
        }
    }
}
