using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public HomeController(ILogger<HomeController> logger, ICourseRepository courseRepo, IProductRepository productRepo, IServiceRepository serviceRepo)
        {
            _courseRepo = courseRepo;
            _serviceRepo = serviceRepo;
            _logger = logger;
            _productRepo = productRepo;
        }

        public IActionResult Index()
        {
            var product = _productRepo.Collection();
            var service = _serviceRepo.Collection();
            var course = _courseRepo.Collection();
            List<ProductServiceCoursesMemberViewModel> viewModel = new List<ProductServiceCoursesMemberViewModel>();
            foreach (var item in product)
            {
                viewModel.Add(new ProductServiceCoursesMemberViewModel()
                {
                    ProductName = item.ProductName,
                    ProductDescription = item.Description
                });
            }
            foreach (var item1 in service)
            {
                viewModel.Add(new ProductServiceCoursesMemberViewModel()
                {
                    ServiceDescription = item1.Description,
                    ServiceName = item1.ServiceName
                });
            }
            foreach (var item2 in course)
            {
                viewModel.Add(new ProductServiceCoursesMemberViewModel()
                {
                    CourseName = item2.CourseName,
                    CourseDescription = item2.CourseDescription,
                   
                });
            }
            return View(viewModel);
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
            var singleProduct = _productRepo.GetSingle(x=>x.Id == id);
            return View(singleProduct);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
