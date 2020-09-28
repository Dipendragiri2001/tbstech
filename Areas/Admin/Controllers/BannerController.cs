using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBSTech.Data;
using TBSTech.Models;
using TBSTech.Repository;

namespace TBSTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : BaseController
    {
        private readonly IBannerRepository _bannerRepo;
        private readonly ApplicationDbContext _context;
        public BannerController(IBannerRepository bannerRepo, ApplicationDbContext context)
        {
            _context = context;
            _bannerRepo = bannerRepo;

        }

        public IActionResult Index()
        {
             var data = _bannerRepo.Collection();
            return View(data);
        }

        public IActionResult New()
        {
            ViewBag.Message = "New";
            var banner = _bannerRepo.Collection().Count();

            if(banner >0)
            {

               return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost]
        public IActionResult New(Banner model, IFormFile file, string message)
        {
            string folderName = "BannerImages";
            string newImage;
            var banner = _bannerRepo.Collection().Count();

            if (message.Equals("Update"))
            {
                string oldImage = _bannerRepo.GetSingle(x => x.Id == model.Id).ImageUrl;
                if (file != null)
                {

                    Console.WriteLine(oldImage);
                    string fileName = Guid.NewGuid().ToString() + file.FileName;
                    newImage = fileName;
                    UpdatePhoto(file, folderName, fileName, oldImage);
                    model.ImageUrl = newImage;

                    _bannerRepo.Update(model);
                }
                else
                {
                    model.ImageUrl = oldImage;
                    _bannerRepo.Update(model);
                }
            }
            else if(banner >0)
            {

              return  RedirectToAction(nameof(Index));
            }
            else if (message.Equals("New")  )
            {
               
                string fileName = Guid.NewGuid().ToString() + file.FileName;

                model.ImageUrl = UploadPhoto(file, folderName, fileName);
                _bannerRepo.Insert(model);

            }
          


            _bannerRepo.Commit();

            return RedirectToAction(nameof(Index));

        }
        public IActionResult Update(int id, IFormFile file)
        {
            ViewBag.Message = "Update";
            var data = _bannerRepo.GetSingle(x => x.Id == id);
            return View(nameof(New), data);
        }
        public IActionResult Delete(int id, IFormFile file)
        {
            string folderName = "BannerImages";
            var courseToDelete = _bannerRepo.GetSingle(x => x.Id == id);
            DeletePhoto(file, folderName, courseToDelete.ImageUrl);
            _bannerRepo.Delete(x => x.Id == id);
            _bannerRepo.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}