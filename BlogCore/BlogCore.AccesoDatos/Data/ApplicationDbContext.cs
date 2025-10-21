using BlogCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //SIEMPRE NOS VA  PERMITR REALIZAR UNA CONEXION A BASE DE DATOS Y REALIZAR OPERACIONES DE MIGRACION
        // TODOS LOS MODELOS QUE SE DESEAN CREAR
        public DbSet<Categoria> Categoria { get; set; }

    }
}
