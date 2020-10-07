using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TBSTech.Data;
using TBSTech.Models;
using TBSTech.Repository;
using TBSTech.ViewModels;

namespace TBSTech.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    [Authorize]

    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductRepository _productRepo;
        private readonly IMemberRepository _memberRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly IServiceRepository _serviceRepo;
        private readonly ApplicationDbContext _context;

        public HomeController(SignInManager<ApplicationUser> signInManager, ApplicationDbContext context,
            ILogger<LoginModel> logger,
            UserManager<ApplicationUser> userManager,IProductRepository productRepo,
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
            _context = context;


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
        
        public  IActionResult UserManager()
        {

            var data =  _context.Users.ToList();
            return View(data);
        }
        public IActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewUser(User model)
        {
          
            var newUser = new ApplicationUser {UserName =model.Username };

            await _userManager.CreateAsync(newUser,model.Password);

            return RedirectToAction(nameof(UserManager));
        }

        public IActionResult Delete(string id)
        {
            var data = _context.Users.FirstOrDefault(x=>x.Id == id);
            _userManager.DeleteAsync(data);
            return View(nameof(UserManager));
        }
        
    }
}