using CrudContactosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudContactosMVC.Data
{
    public class ApplicationDBContext : DbContext // ApplicationDBContext va a heredar una clase llamada DbContext (Proveniente de entityFramework core)
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)//Metodo constructor recibe la configuracion o provedor en este caso recibe a cadena de conexion
            : base(options) // El base options forma parte de la programacion orientada a objetos y la herencia,  los parametros de ApplicationDBContext options base se van a heredar tambien base options
        {
            
        }

        // DBSets
        public DbSet<Contacto> Contactos { get; set; } // DbSet es una clase que representa una coleccion de entidades en la base de datos, en este caso Contactos es el nombre de la tabla y Contacto es el modelo que representa cada registro de la tabla
    }
}
