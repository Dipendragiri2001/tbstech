using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBSTech.Models;
using TBSTech.Repository;

namespace TBSTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;

        }

        public IActionResult Index()
        {
            var data = _productRepo.Collection();
            return View(data);
        }
        public IActionResult New()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult New(Product model,IFormFile file)
        {
           
                model.ImageUrl = UploadedFile(file);
            
                _productRepo.Insert(model);
                _productRepo.Commit();

                return RedirectToAction(nameof(Index));

           
           
        }

         private string UploadedFile(IFormFile file)  
        {  
            var fileName= Guid.NewGuid().ToString()+ file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ProductImages",fileName);

            using(var fileStream = new FileStream(path,FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            
            return fileName;
           
        }  
    }
}