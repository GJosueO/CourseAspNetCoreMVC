using BlogCore.AccesoDatos.Data.Repository.IRepository;// ACCESO A LA INTERFAZ IREPOSITORY
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
{
    // IMPLEMENTACION DEL REPOSITORIO GENERICO QUE PROPORCIONA LAS OPERACIONES COMUNES DE ACCESO A DATOS
    public class Repository<T> : IRepository<T> where T : class // HACEMOS USO DE LA INTERFAZ IREPOSITORY CON SUS METODOS GENERICOS
    {
        // ESTAREMOS CONSTRUYENDO UNA APLICACION AVANZADA
        protected readonly DbContext Context;// PROPIEDAD PROTEGIDA DE SOLO LECTURA QUE ALMACENA EL CONTEXTO DE LA BASE DE DATOS
        internal DbSet<T> dbSet; // PROPIEDAD INTERNA QUE REPRESENTA EL CONJUNTO DE ENTIDADES DEL TIPO T EN EL CONTEXTO DE LA BASE DE DATOS

        public Repository(DbContext context)// CONSTRUCTOR QUE INICIALIZA EL CONTEXTO DE LA BASE DE DATOS Y EL DBSET  AGREGAMOS CONTEXT PARA INYECTAR DEPENDENCIAS
        {
            Context = context;// ASIGNAMOS EL CONTEXTO RECIBIDO A LA PROPIEDAD CONTEXT PARA QUE SEA UTILIZADO EN LOS METODOS DEL REPOSITORIO
            this.dbSet = context.Set<T>(); // INICIALIZAMOS EL DBSET UTILIZANDO EL METODO SET DEL CONTEXTO PARA OBTENER EL CONJUNTO DE ENTIDADES DEL TIPO T
        }
        public void Add(T entity) // IMPLEMENTACION DEL METODO ADD PARA AGREGAR UNA NUEVA ENTIDAD AL DBSET
        {
            dbSet.Add(entity);// UTILIZAMOS EL METODO ADD DEL DBSET PARA AGREGAR LA ENTIDAD RECIBIDA COMO PARAMETRO
        }

        public T Get(int id)// IMPLEMENTACION DEL METODO GET PARA OBTENER UNA ENTIDAD POR SU ID
        {
            return dbSet.Find(id); // UTILIZAMOS EL METODO FIND DEL DBSET PARA OBTENER LA ENTIDAD POR SU ID
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderyBy = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
