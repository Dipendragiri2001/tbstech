using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MimeKit;
using TBSTech.Data;
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
        private readonly ICourseRepository _courseRepo;
        private readonly IVideoRepository _videoRepo;
        private readonly ApplicationDbContext _context;
        private readonly IMemberRepository _memberRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMemberRepository memberRepo, IVideoRepository videoRepo, ICourseRepository courseRepo, IProductRepository productRepo, IServiceRepository serviceRepo)
        {
            _userManager = userManager;
            _context = context;
            _memberRepo = memberRepo;
            _videoRepo = videoRepo;
            _courseRepo = courseRepo;
            _serviceRepo = serviceRepo;
            _logger = logger;
            _productRepo = productRepo;
        }

        public async Task<IActionResult> Index()
        {
            var user = new ApplicationUser { UserName = "dipendragiri2001@gmail.com", Email = "dipendragiri2001@gmail.com" };
            var existing = _context.Users.FirstOrDefault(x => x.Email == user.Email);
            if (existing == null)
            {
               var result=  await _userManager.CreateAsync(user,"p@$$w0Rd");
               foreach(var x in result.Errors)
               {
                   Console.WriteLine(x);
               }
               if(!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,error.Description);
                    }
                    return View();
                }
            }
              
            var product = _productRepo.Collection();
            var service = _serviceRepo.Collection();
            var course = _courseRepo.Collection();

            return View();
        }

        public IActionResult Product()
        {
            var data = _productRepo.Collection();
            return View(data);
        }
        public IActionResult Service(int id)
        {
            var data = _serviceRepo.GetSingle(x => x.Id == id);
            return View(data);
        }
        public IActionResult Course(int id)
        {
            var data = _courseRepo.GetSingle(x => x.Id == id);

            ViewBag.CourseTime = new SelectList(_courseRepo.Collection());

            return View(data);
        }
        public IActionResult Member()
        {
            var data = _memberRepo.Collection();
            return View(data);
        }
        public IActionResult Contact()
        {
            ViewBag.Courses = new SelectList(_courseRepo.Collection(), "CourseName", "CourseName");

            return View();
        }
        [HttpPost]
        public IActionResult Contact(string firstName, string phonenumber, string email, string courses, string coursetime, string message)
        {

            string msg = "First Name: " + firstName + "<br/> " + "Phone Number: " + phonenumber + "<br/>" + "Student Email: " + email + "<br/> <br/>" + "<b>" + "Student Message: " + message + "<b>" + "Course Time:" + coursetime;
            string s = SendEmail(msg, courses);
            System.Console.WriteLine(s);
            return RedirectToAction(nameof(Contact));

        }
        [HttpPost]
        public IActionResult Subscribe(string email, string subject)
        {

            string msg = "Email: " + email;
            string s = SendEmail(msg, "New Subscribtion");
            System.Console.WriteLine(s);
            return RedirectToAction(nameof(Index));
        }
        public string SendEmail(string Message, string subject)
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential("tbstech.net@gmail.com", "password2001?");
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("noreply@codinginfinite.com"),
                    Subject = subject,
                    Body = Message
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress("dipendragiri2001@gmail.com"));

                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };
                client.Send(mail);
                return "Email Sent Successfully!";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

        }

        public IActionResult ProductDetail(int id)
        {
            var singleProduct = _productRepo.GetSingle(x => x.Id == id);
            return View(singleProduct);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
