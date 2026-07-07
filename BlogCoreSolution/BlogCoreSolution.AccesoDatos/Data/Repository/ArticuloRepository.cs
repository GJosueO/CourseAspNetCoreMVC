using BlogCoreSolution.AccesoDatos.Data.Repository.IRepository;
using BlogCoreSolution.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCoreSolution.AccesoDatos.Data.Repository
{
    public class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {
        private readonly ApplicationDbContext _db;
        public ArticuloRepository(ApplicationDbContext db) : base (db) //LLAMA AL CONSTRUCTOR DE LA CLASE BASE (REPOSITORY) PARA INICIALIZAR EL CONTEXTO DE LA BASE DE DATOS
        {
            _db = db;
        }
        public void Update(Articulo articulo)
        {
            var objDesdeDb = _db.Articulos.FirstOrDefault(s => s.Id == articulo.Id);
            objDesdeDb.Nombre = articulo.Nombre;
            objDesdeDb.Descripcion = articulo.Descripcion;  
            objDesdeDb.UrlImagen = articulo.UrlImagen;
            objDesdeDb.Categoria = articulo.Categoria;

            //_db.SaveChanges();
        }
    }
}
