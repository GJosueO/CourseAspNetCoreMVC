using CrudNet9MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNet9MVC.Data
{
    public class ApplicationDBContext:DbContext //La heredacion - DbContext es propia de entity framework
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) //metodo - ctor
        {
            
        }

        //Agregar modelos , cada modelo corresponde a una tabla a base de datos.
        public DbSet<Contacto> ModeloContacto { get; set; } //Si no agrego  los modelos, esta no va a ser reconocida
    
    }
}
