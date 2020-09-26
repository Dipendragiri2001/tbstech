using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBSTech.Models;
using TBSTech.Repository;

namespace TBSTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CourseController : BaseController
    {
        private readonly ICourseRepository _courseRepo;
        public CourseController(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;

        }
        public IActionResult Index()
        {
            var data = _courseRepo.Collection();
            return View(data);
        }
         public IActionResult New()
        {
            ViewBag.Message = "New";
            return View();
        }
        [HttpPost]
        public IActionResult New(Course model,IFormFile file,string message)
        {
            string folderName = "CourseImages";
            string newImage;

            if (message.Equals("Update"))
            {
                string oldImage = _courseRepo.GetSingle(x => x.Id == model.Id).ImageUrl;
                if (file != null)
                {

                    Console.WriteLine(oldImage);
                    string fileName = Guid.NewGuid().ToString() + file.FileName;
                    newImage = fileName;
                    UpdatePhoto(file, folderName, fileName, oldImage);
                    model.ImageUrl = newImage;

                    _courseRepo.Update(model);
                }
                else
                {
                    model.ImageUrl = oldImage;
                    _courseRepo.Update(model);
                }
            }
            else if (message.Equals("New"))
            {
                string fileName = Guid.NewGuid().ToString() + file.FileName;

                model.ImageUrl = UploadPhoto(file, folderName, fileName);
                _courseRepo.Insert(model);

            }


            _courseRepo.Commit();

            return RedirectToAction(nameof(Index));

        }
        public IActionResult Update(int id, IFormFile file)
        {
              ViewBag.Message = "Update";
            var data = _courseRepo.GetSingle(x => x.Id == id);
            return View(nameof(New), data);
        }
        public IActionResult Delete(int id,IFormFile file)
        {
            string folderName = "CourseImages";
            var courseToDelete= _courseRepo.GetSingle(x=>x.Id==id);
            DeletePhoto(file,folderName,courseToDelete.ImageUrl);
            _courseRepo.Delete(x=>x.Id == id);
            _courseRepo.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}