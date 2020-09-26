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

    public class ServiceController : BaseController
    {
        private readonly IServiceRepository _serviceRepo;

        public ServiceController(IServiceRepository serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        public IActionResult Index()
        {
            var services =_serviceRepo.Collection();
            return View(services);
        }
        public IActionResult New()
        {
            ViewBag.Message= "New";
            return View();
        }
        [HttpPost]
        public IActionResult New(Service model, IFormFile file,string message)
        {
            string folderName= "ServiceImages";
            string newImage;
            if(message.Equals("Update"))
            {
                string oldImage = _serviceRepo.GetSingle(x=>x.Id== model.Id).ImageUrl;
                if(file!=null){
                string fileName = Guid.NewGuid().ToString() + file.FileName;
                newImage = fileName; 
                UpdatePhoto(file,folderName,fileName,oldImage);
                model.ImageUrl = newImage;
                _serviceRepo.Update(model);
                }
                else{
                    model.ImageUrl = oldImage;
                    _serviceRepo.Update(model);
                }
            }
            else if(message.Equals("New"))
            {
                string fileName = Guid.NewGuid().ToString() + file.FileName;

                model.ImageUrl = UploadPhoto(file,folderName,fileName);
            
                _serviceRepo.Insert(model);
            }
                _serviceRepo.Commit();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id, IFormFile file)
        {
            var data = _serviceRepo.GetSingle(x=>x.Id ==id);
            return RedirectToAction(nameof(Index),data);
        }
    }
}