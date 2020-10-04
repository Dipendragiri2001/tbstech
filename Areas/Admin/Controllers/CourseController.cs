using System;
using System.Linq;
using ClientNotifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TBSTech.Data;
using TBSTech.Models;
using TBSTech.Repository;
using Microsoft.EntityFrameworkCore;
namespace TBSTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CourseController : BaseController
    {
        private readonly ICourseRepository _courseRepo;
        private readonly ApplicationDbContext _context;
        public CourseController(ICourseRepository courseRepo, ApplicationDbContext context, IToastNotification _clientNotification) : base(_clientNotification)
        {
            _context = context;
            _courseRepo = courseRepo;
        }
        public IActionResult Index()
        {
            var data = _context.Courses.Include(x=>x.CourseTimes).ToList();
            return View(data);
        }
        public IActionResult New()
        {
            ViewBag.Message = "New";
            return View();
        }
        [HttpPost]
        public IActionResult New(Course model, string message)
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
            var data = _context.Courses.Include(x=>x.CourseTimes).FirstOrDefault(x => x.Id == id);
            return View(nameof(New), data);
        }
        public IActionResult Delete(int id, IFormFile file)
        {
            string folderName = "CourseImages";
            var courseToDelete = _courseRepo.GetSingle(x => x.Id == id);
            DeletePhoto(file, folderName, courseToDelete.ImageUrl);
            _courseRepo.Delete(x => x.Id == id);
            _courseRepo.Commit();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CourseTimeIndex()
        {
            var data = _context.Courses.Include(x=>x.CourseTimes).ToList();
            return View(data);
        }
          public IActionResult CourseTime(int id)
        {
            var data = _context.CourseTimes.Include(x=>x.Course).Where(x=>x.CourseId==id).OrderBy(x=>x.Id).ToList();
            if(_context.CourseTimes.FirstOrDefault(x=>x.Id ==id) == null)
            {
                noCourseNotify();
                return RedirectToAction(nameof(CourseTimeIndex));
            }
            return View(data);
        }
        public IActionResult NewCourseTime(int id)
        {
            ViewBag.Message = "New";

           ViewBag.CourseName= _context.Courses.FirstOrDefault(x=>x.Id== id).CourseName;
           ViewBag.CourseId= _context.Courses.FirstOrDefault(x=>x.Id== id).Id;

            
            return View();
        }

        [HttpPost]
        public IActionResult NewCourseTime(CourseTime model, string message)
        {
            Console.WriteLine(model.CourseId);
           ViewBag.CourseName= _context.Courses.FirstOrDefault(x=>x.Id== model.CourseId).CourseName;

            var courseTime = _context.CourseTimes.FirstOrDefault(x=>x.CourseId == model.CourseId);
            if (message.Equals("Update"))
            {
                _context.CourseTimes.Update(courseTime);
                updateNotify();
            }
            else if (message.Equals("New"))
            {
               
                _context.CourseTimes.Add(model);
                addNotify();
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(CourseTimeIndex));
        }
      
          public IActionResult UpdateCourseTime(int id)
        {
            ViewBag.Message = "Update";
           ViewBag.CourseName= _context.Courses.FirstOrDefault(x=>x.Id== id).CourseName;

            var data = _context.CourseTimes.FirstOrDefault(x => x.Id == id);
            return View(nameof(NewCourseTime), data);
        }
         public IActionResult DeleteCourseTime(int id, IFormFile file)
        {
            
            var courseToDelete = _context.CourseTimes.FirstOrDefault(x=>x.Id ==id);
           
            _context.Remove(courseToDelete);
            _context.SaveChanges();
            return RedirectToAction(nameof(CourseTime));
        }
    }
}