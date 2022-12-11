using ArrnowConstruct.Core.Constants;
using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Post;
using ArrnowConstruct.Core.Models.Site;
using ArrnowConstruct.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
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
            var model = new PostFormViewModel()
            {
                SiteId = siteId
            };

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
        public async Task<IActionResult> PostsByUserId(string id)
        {
            var constructorId = await constructorService.GetConstructorId(id);
            IEnumerable<PostViewModel> myPosts = await postService.AllPostsByConstructor(constructorId);

            return View("Mine", myPosts);
        }

        [AllowAnonymous]
        public async Task<IActionResult> PostsByConstructorId(int id)
        {
            IEnumerable<PostViewModel> myPosts = await postService.AllPostsByConstructor(id);

            return View("Mine", myPosts);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if ((await postService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Mine));
            }

            var model = await postService.PostDetailsById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await postService.Exists(id)) == false)
            {
                return RedirectToAction("Index", "Home");
            }

            var post = await postService.PostDetailsById(id);

            var model = new PostFormViewModel()
            {
                Id = post.Id,
                Description = post.Description,
                ShortContent = post.ShortContent,
                Title = post.Title,
                Likes = post.Likes,
                SiteId = post.Site.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int postId, PostFormViewModel model)
        {
        //    if (postId != model.Id)
        //    {
        //        return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
        //    }

        //    if ((await postService.Exists(model.Id)) == false)
        //    {
        //        ModelState.AddModelError("", "Post does not exist");

        //        return View(model);
        //    }

        //    if (model.IsActive == false)
        //    {
        //        ModelState.AddModelError(nameof(model.Id), "Post does not exist");

        //        return RedirectToAction("Mine", "Post");
        //    }

        //    if (ModelState.IsValid == false)
        //    {
        //        return RedirectToAction("Mine", "Post");
        //    }


            await postService.Edit(model.Id, model);

            return RedirectToAction(nameof(Mine), new { model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await postService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Mine));
            }

            var requestModel = await postService.PostDetailsById(id);

            return View(requestModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, PostViewModel model)
        {
            if ((await postService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Mine));
            }

            await postService.Delete(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
