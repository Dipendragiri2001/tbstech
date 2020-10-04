using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TBSTech.Data;
using TBSTech.Models;
using TBSTech.Repository;

namespace TBSTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactDetailsController : BaseController
    {
        private readonly IContactDetailsRepository _contactDetailsRepo;
        private readonly ApplicationDbContext _context;
        public ContactDetailsController(IToastNotification _clientNotification, ApplicationDbContext context,
         IContactDetailsRepository contactDetailsRepo) : base(_clientNotification)
        {
            _context = context;
            _contactDetailsRepo = contactDetailsRepo;
        }

        public IActionResult Index()
        {
            var data = _contactDetailsRepo.Collection();
            return View(data);
        }
        public IActionResult New()
        {
            var data = _context.ContactDetails.ToList().Count();
            if (data >0)
            {
                contactDetailsNotify();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost]
        public IActionResult New(ContactDetail model, string message)
        {

            if (message.Equals("Update"))
            {
                _contactDetailsRepo.Update(model);
                updateNotify();
            }
            else if (message.Equals("New"))
            {
                _contactDetailsRepo.Insert(model);
                addNotify();
            }
            _contactDetailsRepo.Commit();

            return RedirectToAction(nameof(Index));

        }
        public IActionResult Update(int id)
        {
            ViewBag.Message = "Update";
            var data = _contactDetailsRepo.GetSingle(x => x.Id == id);
            return View(nameof(New), data);
        }
        public IActionResult Delete(int id)
        {

            var courseToDelete = _contactDetailsRepo.GetSingle(x => x.Id == id);

            _contactDetailsRepo.Delete(x => x.Id == id);
            _contactDetailsRepo.Commit();
            deleteNotify();
            return RedirectToAction(nameof(Index));
        }
    }
}