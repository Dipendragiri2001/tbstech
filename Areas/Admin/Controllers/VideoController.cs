using System;
using ClientNotifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TBSTech.Models;
using TBSTech.Repository;

namespace TBSTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class VideoController : BaseController
    {
        private readonly IVideoRepository _videoRepo;
        public VideoController(IVideoRepository videoRepo, IToastNotification _clientNotification) : base(_clientNotification)
        {
            _videoRepo = videoRepo;

        }

        public IActionResult Index()
        {
            var data = _videoRepo.Collection();
            return View(data);
        }
        public IActionResult New()
        {
            ViewBag.Message = "New";
            return View();
        }
        [HttpPost]
        public IActionResult New(Video model, IFormFile file, string message)
        {
            string folderName = "Videos";
            string newVideo;
            if (message.Equals("Update"))
            {
                string oldVideo = _videoRepo.GetSingle(x => x.Id == model.Id).VideoUrl;
                if (file != null)
                {


                    string fileName = Guid.NewGuid().ToString() + file.FileName;
                    newVideo = fileName;
                    UpdatePhoto(file, folderName, fileName, oldVideo);
                    model.VideoUrl = newVideo;

                    _videoRepo.Update(model);
                }
                else
                {
                    model.VideoUrl = oldVideo;
                    _videoRepo.Update(model);
                }
            }
            else if (message.Equals("New"))
            {
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + file.FileName;

                    model.VideoUrl = UploadPhoto(file, folderName, fileName);
                    _videoRepo.Insert(model);
                }
                else
                {
                    photoNotify();
                    ViewBag.Message = "New";
                    return View(model);
                }
            }


            _videoRepo.Commit();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id, IFormFile file)
        {
            ViewBag.Message = "Update";
            var data = _videoRepo.GetSingle(x => x.Id == id);
            return View(nameof(New), data);
        }
        public IActionResult Delete(int id, IFormFile file)
        {
            string folderName = "Videos";
            var courseToDelete = _videoRepo.GetSingle(x => x.Id == id);
            DeletePhoto(file, folderName, courseToDelete.VideoUrl);
            _videoRepo.Delete(x => x.Id == id);
            _videoRepo.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}