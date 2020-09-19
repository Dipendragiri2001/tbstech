using Microsoft.AspNetCore.Mvc;

namespace TBSTech.Controllers
{
    public class AdminController :Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            
            return View();
        }

    }
}