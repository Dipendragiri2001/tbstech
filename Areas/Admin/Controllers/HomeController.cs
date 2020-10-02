using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TBSTech.Repository;
using TBSTech.ViewModels;

namespace TBSTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    [Authorize]

    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IProductRepository _productRepo;
        private readonly IMemberRepository _memberRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly IServiceRepository _serviceRepo;
        public HomeController(SignInManager<IdentityUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager,IProductRepository productRepo,
         IServiceRepository serviceRepo, 
         IMemberRepository memberRepo, 
         ICourseRepository courseRepo)
        {
            _serviceRepo = serviceRepo;
            _courseRepo = courseRepo;
            _memberRepo = memberRepo;
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _productRepo = productRepo;

        }
        [HttpGet]
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