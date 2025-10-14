using System.Diagnostics;
using System.Threading.Tasks;
using CrudNet9MVC.Data;
using CrudNet9MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudNet9MVC.Controllers
{
    public class InicioController : Controller
    {
        //Podremos llamar los modelos de ApplicationDBCOntext
        private readonly ApplicationDBContext _context;

        public InicioController(ApplicationDBContext context)
        {
            _context = context; //Accedemos al contexto
        }
        [HttpGet]
        public async Task<IActionResult> Index() //agregamos el metodo async 
        {
            return View(await _context.ModeloContacto.ToListAsync()); // Accedemos al modelo, mandar los registros de bd a una lista
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost] //METODO PARA CREAR DATOS
        [ValidateAntiForgeryToken] // Evitar ataques DE tipo CSRF
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                contacto.FechaCreacion = DateTime.Now;
                _context.ModeloContacto.Add(contacto); //Agregar el contacto a la bd informacion
                await _context.SaveChangesAsync(); //Guardar los cambios conectamos con la bd
                return RedirectToAction(nameof(Index)); //Redireccionar al metodo Index
            }
            return View();
        }

        //METODO PARA VALIDAR REGISTRO DE VISTA EDITAR
        [HttpGet]//METODO PARA obtener         
        public IActionResult Editar(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var contacto = _context.ModeloContacto.Find(id);
            if(contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        // METODO PARA ACTUALIZAR
        [HttpPost] // METODO PARA EDITAR 
        [ValidateAntiForgeryToken] // Evitar ataques CSRF
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid) //VALIDACION DE DATOS ( MODELO CAMPOS NO NULOS)
            {
                contacto.FechaCreacion = DateTime.Now; //Actualizar la fecha de creacion YA QUE NO HAY FECHA DE ACTUALIZACION
                _context.Update(contacto); //Actualizar el contacto
                await _context.SaveChangesAsync(); //Guardar los cambios
                return RedirectToAction(nameof(Index)); //Redireccionar al metodo Index
            }
            return View();
        }
        public IActionResult Privacy()
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
