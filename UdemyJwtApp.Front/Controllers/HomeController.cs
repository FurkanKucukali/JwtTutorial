using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UdemyJwtApp.Front.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public string AdminPage()
        {
            return "Admin Page";
        }

        [Authorize(Roles = "Member")]
        public string MemberPage() 
        {
                return "Member Page";
        }
    }
}
