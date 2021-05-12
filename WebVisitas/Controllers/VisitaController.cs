using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebVisitas.Controllers
{
    public class VisitaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;


        public VisitaController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            try
            {
                string observaciones = HttpContext.Request.Form["FirstName"] + "\nComentario: " + HttpContext.Request.Form["observaciones"];
                string separar = "\n___________________\n";
                string fecha = System.DateTime.Now.ToString("yyyyMMdd");
                string hora = System.DateTime.Now.ToString("HH:mm:ss");

                System.IO.StreamWriter archivo = new StreamWriter(Path.Combine(webRootPath, "archivo.txt"), true);
                archivo.WriteLine("\nFecha: " + fecha + "\nHora " + hora + "\nAutor: " + observaciones + separar);
                archivo.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return View();
        }
    }
}
