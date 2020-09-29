using System;
using System.Linq;
using ClientNotifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
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
        public BannerController(IBannerRepository bannerRepo, ApplicationDbContext context,IToastNotification _clientNotification ) : base(_clientNotification)
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
            string folderName = "BannerVideo";
            string newVideo;
             if (message.Equals("Update"))
            {
                string oldVideo = _bannerRepo.GetSingle(x => x.Id == model.Id).ImageUrl;
                if (file != null)
                {

                    
                    string fileName = Guid.NewGuid().ToString() + file.FileName;
                    newVideo = fileName;
                    UpdatePhoto(file, folderName, fileName, oldVideo);
                    model.ImageUrl = newVideo;

                    _bannerRepo.Update(model);
                    updateNotify();
                }else{
                model.ImageUrl = oldVideo;
                _bannerRepo.Update(model);
                updateNotify();
                }
            }
            else if (message.Equals("New"))
            {
                string fileName = Guid.NewGuid().ToString() + file.FileName;

                model.ImageUrl = UploadPhoto(file, folderName,fileName);
                _bannerRepo.Insert(model);
                addNotify();

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
            deleteNotify();
            return RedirectToAction(nameof(Index));
        }
    }
}