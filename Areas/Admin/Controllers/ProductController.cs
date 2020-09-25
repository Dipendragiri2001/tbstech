using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBSTech.Data;
using TBSTech.Models;
using TBSTech.Repository;

namespace TBSTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
        private readonly IProductRepository _productRepo;
        private readonly ApplicationDbContext _context;
        public ProductController(IProductRepository productRepo, ApplicationDbContext context)
        {
            _context = context;
            _productRepo = productRepo;

        }

        public IActionResult Index()
        {
            var data = _productRepo.Collection();
            return View(data);
        }
        public IActionResult New()
        {
            ViewBag.Message = "New";

            return View();
        }

        [HttpPost]
        public IActionResult New(Product model, IFormFile file, string message)
        {
            string folderName = "ProductImages";
            string newImage;
            
            if (message.Equals("Update"))
            {
                string oldImage = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == model.Id).ImageUrl;
                if (file != null)
                {

                    Console.WriteLine(oldImage);
                    string fileName = Guid.NewGuid().ToString() + file.FileName;
                    newImage = fileName;
                    UpdatePhoto(file, folderName, fileName, oldImage);
                    model.ImageUrl = newImage;

                    _productRepo.Update(model);
                }else{
                model.ImageUrl = oldImage;
                _productRepo.Update(model);
                }
            }
            else if (message.Equals("New"))
            {
                string fileName = Guid.NewGuid().ToString() + file.FileName;

                model.ImageUrl = UploadPhoto(file, folderName,fileName);
                _productRepo.Insert(model);

            }


            _productRepo.Commit();

            return RedirectToAction(nameof(Index));



        }
        public IActionResult Update(int id, IFormFile file)
        {
            ViewBag.Message = "Update";
            var data = _productRepo.GetSingle(x => x.Id == id);
            return View(nameof(New), data);
        }


    }
}