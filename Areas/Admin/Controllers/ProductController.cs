using Microsoft.AspNetCore.Mvc;

namespace TBSTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public ProductController()
        {
            
        }

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