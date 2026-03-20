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
        [HttpGet]
        public async Task<IActionResult> Editar(int? Id) // Este metodo permite validar la vista ya que esta sin no contienen un id nos deberia mandar un error (notfound), de lo contrario si el id pertenece a la base de datos retornamos nuestro modelo contactos
        {
            if(Id == null)
            {
                return NotFound();
            }
            var contacto = await _context.Contactos.FindAsync(Id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int Id, Contacto contacto)
        {
            //antes de realizar la validacion del modelo, validamos que el id que regresamos este disponible dentro de un registro del id de la base de datos.
            if(Id != contacto.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException) //Estamos desarrollando concurrencia basica (Esto pasa cuando dos usuario editan el mismo y uno guarda antes que el otro) Este detecta conflictos a la hora de guardar el registro, verifica si el registro sigue existiendo en base de datos. "EVITA ERRORES SILENCIOSOS"
                {
                    if (!ContactoExist(contacto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(contacto);
        }
        private bool ContactoExist(int Id) //METODO PARA VALIDAR QUE ESE Id este dentro de nuestra base de datos
        {
            return _context.Contactos.Any(e => e.Id == Id);
        }

        [HttpGet]
        public async Task<IActionResult> Detalles(int? Id) //METODO PERMITE VISUALIZAR LOS DETALLES DE UN CONTACTO
        {
            if(Id == null) //VALIDAMOS QUE AL REDIGIR A ESTA VISTA SE ENVIE UN ID
            {
                return NotFound();
            }
            var contacto = await _context.Contactos.FirstOrDefaultAsync(e => e.Id == Id); //ESTE PERMITE OBTENER EL PRIMER REGISTRO QUE COINCIDA CON EL ID ENVIADO, SI NO SE ENCUENTRA NINGUN REGISTRO DEVUELVE NULL.
            if (contacto == null) //AQUI SOLO VALIDAMOS QUE EL CONTACTO QUE EXISTIO EN NUESTRA PREVIA VALIDACION , EXISTA EN NUESTRA BASE DE DATOS
            {
                return NotFound();
            }
            return View(contacto); //REGRESA LA VISTA CON LOS DETALLES DEL CONTACTO SELECCIONADO.
        } 
    }
}
