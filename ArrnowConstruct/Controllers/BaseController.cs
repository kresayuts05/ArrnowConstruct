using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
