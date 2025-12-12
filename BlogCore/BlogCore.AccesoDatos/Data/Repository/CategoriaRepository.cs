using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Categoria> GetAllCategoriasOrdenadas()
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria categoria) // Solo se crea un metodo Update en el repositorio de Categoria porque es una operacion especifica que no esta cubierta por los metodos genericos del repositorio base
        {
            var objDesdeDb = _db.Categoria.FirstOrDefault(s => s.Id == categoria.Id);// BUSCAMOS LA CATEGORIA EN LA BASE DE DATOS UTILIZANDO SU ID
            objDesdeDb.Nombre =  categoria.Nombre;// ACTUALIZAMOS EL NOMBRE DE LA CATEGORIA
            objDesdeDb.Orden = categoria.Orden;// ACTUALIZAMOS EL ORDEN DE LA CATEGORIA

            _db.SaveChanges();// GUARDAMOS LOS CAMBIOS EN LA BASE DE DATOS
        }
    }
}
