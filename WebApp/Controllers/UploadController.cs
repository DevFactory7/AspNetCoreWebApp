using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class UploadController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }


        // GET: /<controller>/
        [HttpPost, Route("api/imageupload")]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            var path = Path.Combine(_environment.WebRootPath, @"images\BoardContentUpload");
            var fi = new FileInfo(file.FileName);

            StringBuilder fileName = new StringBuilder();
            fileName.Append(Common.Fc.GetDoubleGuid());
            fileName.Append(fi.Extension);

            using (var fileStream = new FileStream(Path.Combine(path, fileName.ToString()), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok(new { file="/images/boardcontentupload/" + fileName, success = true });
        }
    }
}
