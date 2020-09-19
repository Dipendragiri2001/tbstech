using Microsoft.AspNetCore.Mvc;

namespace TBSTech.Areas.Identity.Pages.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    public class HomeController :Controller
    {
        public HomeController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}