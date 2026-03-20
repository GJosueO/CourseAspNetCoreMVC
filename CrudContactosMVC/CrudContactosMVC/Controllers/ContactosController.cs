using CrudContactosMVC.Data;
using CrudContactosMVC.Models;
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
        [HttpGet] // La peticion GET  es para crear un nuevo contacto, es decir, para mostrar el formulario de creacion.
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost] // La peticion POST es para enviar los datos del formulario al servidor y crear un nuevo contacto en la base de datos. 
        [ValidateAntiForgeryToken] // Esta anotaicon se utiliza para proteger contra ataques CSRF y ataques xss (Cross)
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid) // PERMITE VALIDAR LOS DATOS QUE SE ENVIAN DESDE EL FORMULARIO, SI LOS DATOS SON VALIDOS SE PROCEDE A GUARDAR EN LA BASE DE DATOS, SI NO SON VALIDOS SE DEVUELVE AL MISMO FORMULARIO CON LOS ERRORES DE VALIDACION.
            {
                _context.Add(contacto); // PERMITE AGREGAR LOS DATOS
                await _context.SaveChangesAsync(); // AQUI REALIZA LA CONEXION CON BASE DE DATOS PARA ALMACENAR LA INFORMACION DEL CONTACTO.
                return RedirectToAction(nameof(Index)); //REGRESA A LA VISTA PARA OBTENER LA INFORMACION DE LA BASE DATOS [MEDIANTE LAS PETICIONES POST].
            }
            return View(contacto); // REGRESA AL FORMULARIO (CON VALIDACIONES)
        }
    }
}
