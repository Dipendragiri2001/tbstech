using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMemberRepository memberRepo, IVideoRepository videoRepo, ICourseRepository courseRepo, IProductRepository productRepo, IServiceRepository serviceRepo)
        {
            _context = context;
            _memberRepo = memberRepo;
            _videoRepo = videoRepo;
            _courseRepo = courseRepo;
            _serviceRepo = serviceRepo;
            _logger = logger;
            _productRepo = productRepo;
        }

        public IActionResult Index()
        {
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
        public IActionResult Contact(string firstName, string lastName, string phonenumber, string email, string courses, string message)
        {

            string msg = "First Name: " + firstName + "<br/> " + "Last Name: " + lastName + "<br/> " + "Phone Number: " + phonenumber + "<br/>" + "Student Email: " + email + "<br/> <br/>" + "<b>" + "Student Message: " + message + "<b>";
            string s = SendEmail(msg, courses);
            System.Console.WriteLine(s);
            return View();
        }
        public string SendEmail(string Message, string subject)
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential("dipendragiri2002@gmail.com", "dipendra2001");
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("noreply@codinginfinite.com"),
                    Subject = subject,
                    Body = Message
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress("komalshres@gmail.com"));

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
