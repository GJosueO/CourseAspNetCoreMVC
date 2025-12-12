using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    // Unit of work: Este es una patron de diseño que se utiliza para gestionar las transacciones en una aplicación. Permite agrupar varias operaciones de base de datos en una sola transacción, lo que garantiza que todas las operaciones se completen correctamente o ninguna se aplique en caso de error. En el contexto de los repositorios, la unidad de trabajo coordina la interación entre los diferentes repositorios y asegura la coherencia de los datos.
    public interface IContenedorTrabajo: IDisposable // IDisposable: ES UNA INTERFAZ QUE PERMITE LIBRERAR RECURSOS NO ADMINISTRADOS, COMO CONEXIONES A BASE DE DATOS, ARCHIVOS, ETC. AL IMPLEMENTAR ESTA INTERFAZ, SE PUEDE ASEGURAR QUE LOS RECURSOS SE LIBEREN DE MANERA ADECUADA CUANDO YA NO SE NECESITEN.
    {
        // AQUI SE DEBEN DE IR AGREGANDO TODOS LOS REPOSITORIOS QUE SE VAYAN A UTILIZAR EN LA APLICACION.
        ICategoriaRepository categoriaRepository { get; } // REPOSITORIO DE CATEGORIAS.
        void Save(); // METODO PARA GUARDAR LOS CAMBIOS EN LA BASE DE DATOS.

    }
    
}
