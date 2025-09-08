using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
