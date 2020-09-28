using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TBSTech.Data;
using TBSTech.Models;
using TBSTech.Repository;
using TBSTech.ViewModels;

namespace TBSTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepo;
        private readonly IServiceRepository _serviceRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly IVideoRepository _videoRepo;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IVideoRepository videoRepo, ICourseRepository courseRepo, IProductRepository productRepo, IServiceRepository serviceRepo)
        {
            _context = context;
            _videoRepo = videoRepo;
            _courseRepo = courseRepo;
            _serviceRepo = serviceRepo;
            _logger = logger;
            _productRepo = productRepo;
        }

        public IActionResult Index()
        {
            var product = _productRepo.Collection();
            var service = _serviceRepo.Collection();
            
            return View();
        }

        public IActionResult Product()
        {
            var data = _productRepo.Collection();
            return View(data);
        }
        public IActionResult Course()
        {
            var data = _courseRepo.Collection();
            return View(data);
        }
        public IActionResult ProductDetail(int id)
        {
            var singleProduct = _productRepo.GetSingle(x => x.Id == id);
            return View(singleProduct);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
