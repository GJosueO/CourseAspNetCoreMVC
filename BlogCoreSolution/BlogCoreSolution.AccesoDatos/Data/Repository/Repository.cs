using BlogCoreSolution.AccesoDatos.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BlogCoreSolution.AccesoDatos.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class // ESTA CLASE SE ENCARGA DE HABLAR CON IDENTITY FRAMEWORK CORE PARA REALIZAR LAS OPERACIONES DE BASE DE DATOS, ESTA CLASE ES GENERICA, SE UTILIZARA PARA LA MAYORIA DEL PROYECTO, Y SE REEMPLAZARA CUANDO ENTRE MODELOS "CATEGORIA, ARTICULO"
    {
        protected readonly DbContext Context; // CONTEXTO DE BASE DE DATOS
        internal DbSet<T> dbSet; // CONJUNTO DE ENTIDADES DE TIPO T, SE UTILIZARA PARA REALIZAR OPERACIONES DE BASE DE DATOS
        public Repository(DbContext context) // CONSTRUCTOR QUE RECIBE EL CONTEXTO DE BASE DE DATOS
        {
            Context = context; // ASIGNAR EL CONTEXTO DE BASE DE DATOS A LA PROPIEDAD CONTEXT
            this.dbSet = context.Set<T>(); // OBTENER EL CONJUNTO DE ENTIDADES DE TIPO T DEL CONTEXTO DE BASE DE DATOS
        }
        public void Add(T entity) // METODO PARA AGREGAR UNA ENTIDAD DE TIPO T A LA BASE DE DATOS. T quiere decir que es una clase, y se puede utilizar para cualquier clase que se quiera agregar a la base de datos, como CATEGORIA, ARTICULO, ETC. y Entity es el objeto que se quiere agregar a la base de datos, y se agrega al conjunto de entidades de TIPO T, que es el conjunto de entidades que se utiliza para realizar las operaciones de base de datos. Y este metodo se llama desde el controlador, cuando se quiere agregar una nueva entidad a la base de datos. Y este metodo se encarga de agregar la entidad al conjunto de entidades de TIPO T, y luego se guarda los cambios en la base de datos.
        {
            dbSet.Add(entity); // AGREGAR LA ENTIDAD AL CONJUNTO DE ENTIDADES DE TIPO T
        }

        public T Get(int id)
        {
            return dbSet.Find(id); // OBTENER UNA ENTIDAD DE TIPO T POR ID, UTILIZANDO EL METODO FIND DEL CONJUNTO DE ENTIDADES DE TIPO T, Y RETORNAR LA ENTIDAD OBTENIDA
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public T GetFirstOrDefult(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
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

        // DE MANERA GENERAL, EL CONTROLADOR NO CONOCE DE dbcONTEXT,
        // Y ESTO ES DESACOMPLAMIENTO ,
        // EL CONTROLADOR SOLO CONOCE DE LA INTERFAZ IRepository,
        // Y ESTA INTERFAZ ES IMPLEMENTADA POR LA CLASE Repository,
        // QUE A SU VEZ UTILIZA EL CONTEXTO DE BASE DE DATOS PARA REALIZAR LAS OPERACIONES DE BASE DE DATOS.
        //
        // ESTO PERMITE QUE EL CONTROLADOR NO TENGA DEPENDENCIA DIRECTA DEL CONTEXTO DE BASE DE DATOS,
        // Y SE PUEDA CAMBIAR LA IMPLEMENTACION DE LA CLASE Repository SIN AFECTAR AL CONTROLADOR.
    }
}
