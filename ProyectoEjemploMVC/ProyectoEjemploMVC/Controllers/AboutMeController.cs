using Microsoft.AspNetCore.Mvc;

namespace ProyectoEjemploMVC.Controllers
{
    public class AboutMeController : Controller
    {
        public IActionResult Index() //ENRUTAMIENTO SIMPLE (PARAMETROS)
        {
            return Content("I´m Josue");
        }
        public IActionResult Hobbies(int id)
        {
            return Content($"page:" + id);
        }
    }
}
