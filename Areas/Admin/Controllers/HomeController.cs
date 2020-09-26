using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TBSTech.Repository;

namespace TBSTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    [Authorize]

    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly IMemberRepository _memberRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly IServiceRepository _serviceRepo;
        public HomeController(IProductRepository productRepo,
         IServiceRepository serviceRepo, 
         IMemberRepository memberRepo, 
         ICourseRepository courseRepo)
        {
            _serviceRepo = serviceRepo;
            _courseRepo = courseRepo;
            _memberRepo = memberRepo;
            _productRepo = productRepo;

        }
        public IActionResult Index()
        {
            var totalProducts = _productRepo.Collection().Count();
            var totalMember = _memberRepo.Collection().Count();
            var totalCourse = _courseRepo.Collection().Count();
            var totalService = _serviceRepo.Collection().Count();
            ViewBag.TotalProduct = totalProducts;
            ViewBag.TotalMember = totalMember;
            ViewBag.TotalCourse = totalCourse;
            ViewBag.TotalService = totalService;

            return View();
        }

    }
}