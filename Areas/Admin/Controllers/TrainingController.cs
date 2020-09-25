using Microsoft.AspNetCore.Mvc;

namespace TBSTech.Areas.Admin.Controllers
{
    public class TrainingController : Controller
    {
        public TrainingController()
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
        public IActionResult Update()
        {
            return View();
        }
    }
}