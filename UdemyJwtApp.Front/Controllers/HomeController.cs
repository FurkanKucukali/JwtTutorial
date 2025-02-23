using Microsoft.AspNetCore.Mvc;

namespace UdemyJwtApp.Front.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
