using Microsoft.AspNetCore.Mvc;

namespace Supermarket_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
