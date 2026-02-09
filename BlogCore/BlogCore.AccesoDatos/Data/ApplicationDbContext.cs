using BlogCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogCore.AccesoDatos.Data
{
  
        public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : IdentityDbContext(options) // heredamos de IdentityDbContext y no de DbContext porque  se utlizara itentity para la gestion de usuarios // aparte el proyecto fue creado con autenticacion individual (identity)
        {
            //SIEMPRE NOS VA  PERMITR REALIZAR UNA CONEXION A BASE DE DATOS Y REALIZAR OPERACIONES DE MIGRACION
            // TODOS LOS MODELOS QUE SE DESEAN CREAR
            public DbSet<Categoria> Categoria { get; set; }
        }

 
}
