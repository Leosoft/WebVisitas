using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebVisitas.Controllers
{
    public class LeerController : Controller
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;


        public LeerController(IWebHostEnvironment webHostEnvironment)
        {
            _WebHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            string webRootPath = _WebHostEnvironment.WebRootPath;
            string data;

            try
            {
                string path = Path.Combine(webRootPath, "archivo.txt");
                data = System.IO.File.ReadAllText(path, Encoding.UTF8);
            }
            catch (Exception e)
            {
                data = "Exception: " + e.Message;
            }


            data = data.Replace("\n", Environment.NewLine);
            return View(null, data);
        }
    }
}
