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
        //RECOPILAR UNA COLECION DE ENTIDADES QUE CUMPLAN CON CRITERIOS ESPECIFICOS
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderyBy = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet; // se crea una consulta base utilizando el DbSet de la entidad T si se esta ejecutando categorias me va a traer todas las categorias, si productos todas los productos
            if(filter != null)
            {
                query = query.Where(filter);//se aplica el filtro a la consulta si se proporciona uno // guardara en query solo los elementos que cumplan con el filtro
            }
            if(includeProperties != null)
            {
                foreach(var includeProperty in includeProperties.Split( new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))// se divide la cadena de propiedades relacionadas en una matriz utilizando la coma como separador y se itera sobre cada propiedad relacionada
                {
                    query = query.Include(includeProperty);// se incluyen las propiedades relacionadas especificadas en la consulta
                }
            }
            // Se aplica el ordenamiento si se proporciona una funcion 
            if (orderyBy != null)
            {
                return orderyBy(query).ToList();// se aplica la funcion de ordenamiento a la consulta y se convierte a una lista antes de devolver los resultados
            }
            return query.ToList();// si no se proporciona una funcion de ordenamiento, se convierte la consulta a una lista y se devuelven los resultados tal cual

        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet; // se crea una consulta base utilizando el DbSet de la entidad T
            // se aplica el filtro a la consulta si se proporciona uno
            if(filter != null)
            {
                query = query.Where(filter);// se guarda en query solo los elementos que cumplan con el filtro
            }
            // se incluyen propiedades de navegacion si se proporcionan
            if (includeProperties != null)
            {
                foreach(var includeProperty in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();// se devuelve la primera entidad que cumple con los criterios especificados o el valor predeterminado si no se encuentra ninguna
        }

        public void Remove(int id)
        {
            T entityToRemove = dbSet.Find(id); // se busca la entidad en el DbSet utilizando el ID proporcionado
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity); // se elimina la entidad especificada del DbSet
        }

        // EL REPOSITORIO GENERICO PROPORCIONA UNA IMPLEMENTACION REUTILIZABLE DE LAS OPERACIONES COMUNES DE ACCESO A DATOS DONDE SE PUEDEN REALIZAR OPERACIONES CRUD BASICAS EN CUALQUIER ENTIDAD DEL MODELO DE DATOS,PERMITE UNA MAYOR CONSISTENCIA Y REDUCCION DE CODIGO DUPLICADO EN LA CAPA DE ACCESO A DATOS DE LA APLICACION.
    }
}
