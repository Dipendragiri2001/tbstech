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

    public class MemberController : BaseController
    {
        private readonly IMemberRepository _memberRepo;
        public MemberController(IMemberRepository memberRepo,IToastNotification _clientNotification ) : base(_clientNotification)
        {
            _memberRepo = memberRepo;

        }

        public IActionResult Index()
        {
            var data = _memberRepo.Collection();
            return View(data);
        }
        public IActionResult New()
        {
            ViewBag.Message = "New";
            return View();
        }
        [HttpPost]
        public IActionResult New(Member model,IFormFile file,string message)
        {
             string folderName = "MemberImages";
            string newImage;
            
            if (message.Equals("Update"))
            {
                string oldImage = _memberRepo.GetSingle(x => x.Id == model.Id).imageUrl;
                if (file != null)
                {

                    Console.WriteLine(oldImage);
                    string fileName = Guid.NewGuid().ToString() + file.FileName;
                    newImage = fileName;
                    UpdatePhoto(file, folderName, fileName, oldImage);
                    model.imageUrl = newImage;

                    _memberRepo.Update(model);
                }else{
                model.imageUrl = oldImage;
                _memberRepo.Update(model);
                }
            }
            else if (message.Equals("New"))
            {
                string fileName = Guid.NewGuid().ToString() + file.FileName;

                model.imageUrl = UploadPhoto(file, folderName,fileName);
                _memberRepo.Insert(model);

            }


            _memberRepo.Commit();

            return RedirectToAction(nameof(Index));


        }
        public IActionResult Update(int id,IFormFile file)
        {
              ViewBag.Message = "Update";
            var data = _memberRepo.GetSingle(x => x.Id == id);
            return View(nameof(New), data);
        }
          public IActionResult Delete(int id, IFormFile file)
        {
            string folderName = "MemberImages";
            var courseToDelete = _memberRepo.GetSingle(x => x.Id == id);
            DeletePhoto(file, folderName, courseToDelete.imageUrl);
            _memberRepo.Delete(x => x.Id == id);
            _memberRepo.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}