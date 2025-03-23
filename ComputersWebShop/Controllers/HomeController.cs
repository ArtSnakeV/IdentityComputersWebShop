using Microsoft.AspNetCore.Mvc;

namespace ComputersWebShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
