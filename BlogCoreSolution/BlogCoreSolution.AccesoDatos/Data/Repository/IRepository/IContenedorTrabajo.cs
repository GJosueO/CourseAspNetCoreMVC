using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCoreSolution.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable // IDISPOSABLE SE UTILIZA PARA LIBERAR LOS RECURSOS QUE SE ESTAN UTILIZANDO, EN ESTE CASO LA CONEXION A LA BASE DE DATOS.
    {
        //  AQUI SE DEBE IR AGREGANDO LOS REPOSITORIOS QUE SE VAYAN CREANDO, POR EJEMPLO:
        // IProductoRepository Producto { get; }
        // ICategoriaRepository Categoria { get; }
        ICategoriaRepository Categoria { get; } // EL OBJETIVO DE ESTE REPOSITORIO ES CONTROLAR LAS CATEGORIAS DE LOS PRODUCTOS.
        void Save(); // ESTE METODO SE ENCARGA DE GUARDAR LOS CAMBIOS EN LA BASE DE DATOS
    }// EL OBJETIVO DE LAS UNIDADES DE TRABAJO, ES CENTRALIZAR TODOS LOS REPOSITORIOS, CONTROLAR CUANDO SE GUARDAN LOS CAMBIOS EN LA BASE DE DAT
}
