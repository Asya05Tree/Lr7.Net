using Lr7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Lr7.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(FileDownloadModel model)
        {
            if (ModelState.IsValid)
            {
                var content = $"{model.FirstName} {model.LastName}";
                var bytes = Encoding.UTF8.GetBytes(content);

                var fileName = model.FileName.EndsWith(".txt") ?
                    model.FileName :
                    $"{model.FileName}.txt";

                return File(bytes, "text/plain", fileName);
            }
            return View(model);
        }
    }
}
