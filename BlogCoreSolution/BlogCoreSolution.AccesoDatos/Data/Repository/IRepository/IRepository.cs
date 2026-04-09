using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BlogCoreSolution.AccesoDatos.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class // T SE REEMPLAZARA CUANDO ENTRE MODELOS "CATEGORIA, ARTICULO" ESTA ES UNA INTERFAZ GENERICA "SE UTILIZARA PARA LA MAYORIA DEL PROYECTO"
    {
        T Get(int id); // OBTENER UN REGISTRO POR ID
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null, // FILTRO PARA OBTENER REGISTROS ESPECIFICOS
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, // ORDENAR LOS REGISTROS
            string? includeProperties = null // PROPIEDADES RELACIONADAS A INCLUIR (EJEMPLO: TIPO EN ARTICULO)
            ); // OBTENER TODOS LOS REGISTROS, CON FILTRO, ORDEN Y PROPIEDADES INCLUIDAS, ESTAS PROPIEDADES SE UTILIZARAN PARA OBTENER DATOS  DE BASE DE DATOS PERO CON ALGUNA DE ESTAS PROPIEDADES INCLUIDAS.
        T GetFirstOrDefult(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null
            ); // OBTENER EL PRIMER REGISTRO QUE CUMPLA CON EL FILTRO, CON PROPIEDADES INCLUIDAS
        void Add(T entity); // AGREGAR UN REGISTRO
        void Remove(int id); // ELIMINAR UN REGISTRO POR ID
        void Remove(T entity); // ELIMINAR UN REGISTRO POR ENTIDAD
    }
}
