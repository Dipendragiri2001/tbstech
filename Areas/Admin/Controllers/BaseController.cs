using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBSTech.Data;

namespace TBSTech.Areas.Admin.Controllers
{
    public class BaseController :Controller
    {
        private readonly ApplicationDbContext _context;
      
         
        
        public string UploadPhoto(IFormFile file, string folderName,string fileName)
        {
          
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + folderName, fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;

        }

        public string UpdatePhoto(IFormFile file,string folderName, string fileName, string oldImage)
        {
            if (oldImage != null)
            {
                var path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot/"+ folderName, oldImage);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            
            UploadPhoto(file, folderName,fileName);
           
            return "OK";

        }
    }
}