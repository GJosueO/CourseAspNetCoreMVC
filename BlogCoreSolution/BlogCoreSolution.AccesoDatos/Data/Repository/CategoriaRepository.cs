using BlogCoreSolution.AccesoDatos.Data.Repository.IRepository;
using BlogCoreSolution.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCoreSolution.AccesoDatos.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoriaRepository(ApplicationDbContext db) : base (db) //LLAMA AL CONSTRUCTOR DE LA CLASE BASE (REPOSITORY) PARA INICIALIZAR EL CONTEXTO DE LA BASE DE DATOS
        {
            _db = db;
        }
        public void Update(Categoria categoria)
        {
            var objDesdeDb = _db.Categorias.FirstOrDefault(s => s.Id == categoria.Id);
            objDesdeDb.Nombre = categoria.Nombre;
            objDesdeDb.Orden = categoria.Orden;            

            //_db.SaveChanges();
        }
    }
}
