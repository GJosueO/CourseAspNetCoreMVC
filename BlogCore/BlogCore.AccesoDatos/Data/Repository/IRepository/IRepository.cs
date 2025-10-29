using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    // T es un parametro de tipo generico que representa la entidad con la que se va a trabajar (class, interfaz o metodo)
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderyBy = null,
            string? includeProperties = null
            );
        T GetFirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null
            );
        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);
    }
}
