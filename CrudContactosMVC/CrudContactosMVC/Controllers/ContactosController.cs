using CrudContactosMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudContactosMVC.Controllers
{
    public class ContactosController : Controller
    {
        //LLAMAR AL APPLICATION DBCONTEXT PARA HACER LA PETICION A BASE DE DATOS.
        private readonly ApplicationDBContext _context; // este viene cargado con inyeccion de dependencias.
        // CREAMOS EL CONSTRUCTOR PARA HACER USO DEL DBcontext
        public ContactosController(ApplicationDBContext context)//ESTE NOS SERVIRA PARA HACER INSERCION, LECTURA DE DATOS Y MAS.
        {
            _context = context;
        }
        // GET : COntactos
        [HttpGet]
        public async Task<IActionResult> Index() //ASYNC Y AWAIT LOS UTILIZAMOS YA QUE SON UNA NUEVA BUENA PRACTICA.
        {
            var contactos = await _context.Contactos.ToListAsync();
            return View(contactos);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
    }
}
