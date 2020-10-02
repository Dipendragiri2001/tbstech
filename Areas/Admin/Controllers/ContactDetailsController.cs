using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TBSTech.Models;
using TBSTech.Repository;

namespace TBSTech.Areas.Admin.Controllers
{
    public class ContactDetailsController : BaseController
    {
        private readonly IContactDetailsRepository _contactDetailsRepo;
        public ContactDetailsController(IToastNotification _clientNotification, IContactDetailsRepository contactDetailsRepo) : base(_clientNotification)
        {
            _contactDetailsRepo = contactDetailsRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult New()
        {
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