using BlogCoreSolution.AccesoDatos.Data.Repository.IRepository;
using BlogCoreSolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        //AQUI YA NO SE TRABAJA DIRECTAMENTE CON DBCONTEXT SI NO CON LA UNIDIAD DE TRABAJO 
        // CONTENEDOR DE TRABAJO > REPOSITORIO > FUNCIONALIDAD IDENTITY FRAMEWORK CORE > DBCONTEXT > BASE DE DATOS

        private readonly IContenedorTrabajo _contenedorTrabajo; // INYECCION DE DEPENDENCIA PARA LA UNIDAD DE TRABAJO

        public CategoriasController(IContenedorTrabajo contenedorTrabajo) // CONSTRUCTOR PARA INYECTAR LA UNIDAD DE TRABAJO
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet] // ACCION PARA MOSTRAR LA VISTA PRINCIPAL DE CATEGORIAS
        public IActionResult Index() // DEVUELVE LA VISTA PRINCIPAL DE CATEGORIAS
        {
            return View();// DEVUELVE LA VISTA PRINCIPAL
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid) //PERMITE VALIDAR TODOS LOS DATOS QUE SE ENVIAN DESDE EL FORMULARIO.
            {
                //LOGICA PARA CREAR UNA CATEGORIA
                _contenedorTrabajo.Categoria.Add(categoria); //AGREGA LA CATEGORIA A LA BASE DE DATOS
                _contenedorTrabajo.Save(); //GUARDA LOS CAMBIOS EN LA BASE DE DATOS
                return RedirectToAction(nameof(Index)); //REDIRIGE A LA VISTA PRINCIPAL DE CATEGORIAS
            }
            return View();
        }
        #region llamadas a la api
        public IActionResult GetAll() // ACCION PARA OBTENER TODAS LAS CATEGORIAS EN FORMATO JSON PARA LA API
        {
            return Json(new { data = _contenedorTrabajo.Categoria.GetAll() }); // DEVUELVE LAS CATEGORIAS EN FORMATO JSON este ya esta implementado en el repositorio generico
        }
        #endregion

    }
}
