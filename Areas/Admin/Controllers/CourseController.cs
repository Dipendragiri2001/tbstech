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
    public class CourseController : BaseController
    {
        private readonly ICourseRepository _courseRepo;
        public CourseController(ICourseRepository courseRepo,IToastNotification _clientNotification ) : base(_clientNotification)
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
        public IActionResult New(Course model,string message)
        {
           
            if (message.Equals("Update"))
            {
                    _courseRepo.Update(model);
                    updateNotify();
            }
            else if (message.Equals("New"))
            { 
                _courseRepo.Insert(model);
                addNotify();
            }
            _courseRepo.Commit();

            return RedirectToAction(nameof(Index));

        }
        public IActionResult Update(int id)
        {
              ViewBag.Message = "Update";
            var data = _courseRepo.GetSingle(x => x.Id == id);
            return View(nameof(New), data);
        }
        public IActionResult Delete(int id,IFormFile file)
        {
           
            var courseToDelete= _courseRepo.GetSingle(x=>x.Id==id);
           
            _courseRepo.Delete(x=>x.Id == id);
            _courseRepo.Commit();
            deleteNotify();
            return RedirectToAction(nameof(Index));
        }
         
    }
}