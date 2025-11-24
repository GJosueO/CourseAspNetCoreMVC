using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    // T es un parametro de tipo generico que representa la entidad con la que se va a trabajar (class, interfaz o metodo)
    // INTERFAZ PARA EL REPOSITORIO GENERICO QUE NO ESTA ASOCIADO A NINGUNA ENTIDAD ESPECIFICA CON EL PROPOSITO DE DEFINIR LAS OPERACIONES COMUNES DE ACCESO A DATOS
    public interface IRepository<T> where T : class 
    {
        T Get(int id); // Metodo para obtener una entidad por su ID

        IEnumerable<T> GetAll(// Metodo para obtener todas las entidades con filtros opcionales
            Expression<Func<T, bool>>? filter = null,// Expresion lambda para filtrar los resultados
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderyBy = null, // Funcion para ordenar los resultados
            string? includeProperties = null // Propiedades relacionadas para incluir en la consulta
            );
        T GetFirstOrDefault(// Metodo para obtener la primera entidad que cumple con un filtro especifico
            Expression<Func<T, bool>>? filter = null,// Expresion lambda para filtrar los resultados
            string? includeProperties = null // Propiedades relacionadas para incluir en la consulta
            );
        void Add(T entity); // Metodo para agregar una nueva entidad
        void Remove(int id); // Metodo para eliminar una entidad por su ID
        void Remove(T entity); // Metodo para eliminar una entidad especifica
    }
    // UNA INTERFAZ ES UN CONTRATO QUE DEFINE UN CONJUNTO DE METODOS Y PROPIEDADES QUE UNA CLASE DEBE IMPLEMENTAR
    // PARA ENTENDERLO MEJOR, IMAGINA UNA INTERFAZ COMO UN PLAN O UNA LISTA DE INSTRUCCIONES QUE UNA CLASE DEBE SEGUIR+
}
