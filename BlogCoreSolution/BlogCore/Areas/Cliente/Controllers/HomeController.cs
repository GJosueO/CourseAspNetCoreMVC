using BlogCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogCore.Areas.Cliente.Controllers
{
    public class HomeController : Controller
    {
        [Area("Cliente")] // ESTE ATRIBUTO ES IMPORTANTE PARA INDICAR QUE ESTE CONTROLADOR PERTENECE AL AREA "Cliente"
        public IActionResult Index()
        {
            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
