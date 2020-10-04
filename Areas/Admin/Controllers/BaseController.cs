using System;
using System.IO;
using System.Linq;
using ClientNotifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TBSTech.Data;
using static ClientNotifications.Helpers.NotificationHelper;

namespace TBSTech.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification __clientNotification;
        public BaseController(IToastNotification _clientNotification)
        {
            __clientNotification = _clientNotification;

        }

        public void addNotify()
        {
            __clientNotification.AddSuccessToastMessage("Your Data Has Been Added Sucessfully");
        }
         public void updateNotify()
        {
            __clientNotification.AddSuccessToastMessage("Your Data Has Been Updated Sucessfully");
        }
         public void deleteNotify()
        {
            __clientNotification.AddSuccessToastMessage("Your Data Has Been Deleted Sucessfully");
        }
          public void photoNotify()
        {
            __clientNotification.AddAlertToastMessage("Please Upload a photo");
        }
          public void bannerNotify()
        {
            __clientNotification.AddAlertToastMessage("You Cannot Add More Than One Banner");
        }
          public void noCourseNotify()
        {
            __clientNotification.AddAlertToastMessage("No Course Time Found!! Please Add The Course Time!!");
        }
           public void contactDetailsNotify()
        {
            __clientNotification.AddAlertToastMessage("You Cannot Add More Than One Contact Details Please Update The Existing One");
        }
        public string UploadPhoto(IFormFile file, string folderName, string fileName)
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + folderName, fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;

        }

        public string UpdatePhoto(IFormFile file, string folderName, string fileName, string oldImage)
        {
            if (oldImage != null)
            {
                var path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot/" + folderName, oldImage);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }

            UploadPhoto(file, folderName, fileName);

            return "OK";

        }
        public string DeletePhoto(IFormFile file, string folderName, string ImageFile)
        {
            if (ImageFile != null)
            {
                var path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot/" + folderName, ImageFile);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            return "Ok";

        }
    }
}