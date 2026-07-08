using BlogCoreSolution.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticulosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo; // INYECCION DE DEPENDENCIA PARA LA UNIDAD DE TRABAJO
        public ArticulosController(IContenedorTrabajo contenedorTrabajo) // CONSTRUCTOR PARA INYECTAR LA UNIDAD DE TRABAJO
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        public IActionResult Index() // ACCION PARA MOSTRAR LA VISTA PRINCIPAL DE ARTICULOS
        {
            return View();
        }

        #region llamadas a la api
        public IActionResult GetAll() // ACCION PARA OBTENER TODAS LAS CATEGORIAS EN FORMATO JSON PARA LA API
        {
            return Json(new { data = _contenedorTrabajo.Articulo.GetAll() }); // DEVUELVE LAS CATEGORIAS EN FORMATO JSON este ya esta implementado en el repositorio generico
        }

        //SWEETALERT 
        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var objFromDb = _contenedorTrabajo.Categoria.Get(id);
        //    if (objFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Error borrando categoria." });
        //    }
        //    _contenedorTrabajo.Categoria.Remove(objFromDb);
        //    _contenedorTrabajo.Save();
        //    return Json(new { success = true, message = $"Categoria borrada correctamente: {objFromDb.Nombre}" });
        //}
        #endregion
    }
}
