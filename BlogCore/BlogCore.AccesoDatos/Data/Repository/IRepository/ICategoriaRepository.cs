using BlogCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        void Update(Categoria categoria); // EL REPOSITORIO UPDATE SE IMPLEMENTA DE MANERA ESPECIFICA EN ICATEGORIA YA QUE IDENTITYFRAMEWORK NO PROPORCIONA UN METODO UPDATE PREDEFINIDO, POR QUE ES UNA TECNOLOGIA ORM (OBJECT RELATIONAL MAPPING) QUE SE ENCARGA DE MAPEAR LAS ENTIDADES DE LA APLICACION A LAS TABLAS DE LA BASE DE DATOS Y PROPORCIONA METODOS PARA REALIZAR OPERACIONES CRUD (CREAR, LEER, ACTUALIZAR, ELIMINAR) EN LA BASE DE DATOS.
        IEnumerable<Categoria> GetAllCategoriasOrdenadas(); // METODO PARA OBTENER TODAS LAS CATEGORIAS ORDENADAS POR EL CAMPO ORDEN
    }
}
