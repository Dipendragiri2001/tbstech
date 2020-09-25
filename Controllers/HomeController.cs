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

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepo, IServiceRepository serviceRepo)
        {
            _serviceRepo = serviceRepo;
            _logger = logger;
            _productRepo = productRepo;
        }

        public IActionResult Index()
        {
            var product = _productRepo.Collection();
            var service = _serviceRepo.Collection();
            List<ProductServiceCoursesViewModel> viewModel = new List<ProductServiceCoursesViewModel>();
            foreach(var item in product)
            {
                viewModel.Add(new ProductServiceCoursesViewModel()
                {
                    ProductName = item.ProductName,
                    ProductDescription = item.Description    
                });
            }
            foreach(var item1 in service)
            {
                 viewModel.Add(new ProductServiceCoursesViewModel()
                {
                    ServiceDescription = item1.Description,
                    ServiceName = item1.ServiceName    
                });
            }
            return View(viewModel);
        }

        public IActionResult Product()
        {
            var data = _productRepo.Collection();
            return View(data);
        }
        public IActionResult Members()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
