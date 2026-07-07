using BlogCoreSolution.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCoreSolution.AccesoDatos.Data.Repository.IRepository
{
    // REGLAS PROPIAS DE ARTICULO, METODOS ESPECIFICOS PARA ARTICULO, Y QUE NO APLICAN A OTRA ENTIDAD.
    public interface IArticuloRepository : IRepository<Articulo> //HEREDA DE REPOSITORY, PORQUE ARTICULO ES UNA ENTIDAD
    {
        //¿por que el metodo update No va en el repository generico?
        void Update(Articulo articulo); //VA IMPLEMENTAR METODO UPDATE, PARA ACTUALIZAR ARTICULOS (METODO PROPIO) -- POR QUE REPOSITORY SOLO TIENE LOS METODOS GENERICOS, PERO SI QUIERO UN METODO ESPECIFICO PARA ARTICULO, LO AGREGO AQUI
                                          // 1) CADA ENTIDAD SE ACTUALIZA DISTINTO
                                          //Categoria: Nombre, Orden
                                          // Post:TItulo, contenido, imagen, fecha
                                          // Usuarios: Datos distintos
                                          // No todas las propiedades se deben actualizar.
                                          //Algunas de ignoran
                                          // otras de calculan
                                          // Otras no se tocan nunca
                                          // Evita errores
                                          // Update(entity)  generico puede marcar todo como modificado, lo que no es correcto
                                          // Riesgo de sobreescribir datos sin querer

        //ESTO PERMITE EL COMPORTAMIENTO ESPECIFICO O PROPIO DE CATEGORIA, SIN AFECTAR A OTRAS ENTIDADES, Y MANTIENE EL REPOSITORIO GENERICO LIMPIO Y REUTILIZABLE PARA OTRAS ENTIDADES
    }
}
