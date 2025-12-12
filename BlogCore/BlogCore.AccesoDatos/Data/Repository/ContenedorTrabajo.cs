using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo // IMPLEMENTACION DE LA INTERFAZ ICONTENEDORTRABAJO PARA UINIT OF WORK, QUE PERMITE AGRUPAR VARIAS OPERACIONES DE BASE DE DATOS EN UNA SOLA TRANSACCION.
    {
        private readonly ApplicationDbContext _db; // INSTANCIA PARA ACCEDER A LA BASE DE DATOS.
        public ContenedorTrabajo(ApplicationDbContext db) //CONSTRUCTOR QUE RECIBE LA INTANCIA DE LA BASE DE DATOS Y CREA EL REPOSITORIO DE CATEGORIAS. ESTE PERMITE QUE TODOS LOS REPOSITORIOS COMPARTAN LA MISMA INSTANCIA DE LA BASE DE DATOS, GARANTIZANDO LA COHERENCIA DE LOS DATOS.
        {
            _db = db;
            categoriaRepository = new CategoriaRepository(_db);
        }

        public ICategoriaRepository categoriaRepository { get; private set; } // PROPIEDAD PARA ACCEDER AL REPOSITORIO DE CATEGORIAS.

        public void Dispose() // ESTE METODO PERMITE LIBERAR LOS RECURSOS DE LA BASE DE DATOS QUE YA NO SE NECESITAN.
        {
            _db.Dispose();
        }

        public void Save() // METODO QUE PERMITE GUARDAR LOS CAMBIOS EN LA BASE DE DATOS.
        {
            _db.SaveChanges();
        }

        // ESTA CLASE GENERALMENTE SE UTILIZA PARA AGRUPAR VARIOS REPOSITORIOS Y PERMITIR QUE LAS OPERACIONES DE BASE DE DATOS SE REALICEN DE MANERA COHERENTE Y EFICIENTE.
    }
}
