using Microsoft.AspNetCore.Mvc;

namespace TBSTech.Areas.Identity.Pages.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
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