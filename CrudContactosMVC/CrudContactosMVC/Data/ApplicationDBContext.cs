using Microsoft.EntityFrameworkCore;

namespace CrudContactosMVC.Data
{
    public class ApplicationDBContext : DbContext // ApplicationDBContext va a heredar una clase llamada DbContext (Proveniente de entityFramework)
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)//Metodo constructor recibe la configuracion o provedor 
            : base(options) // El base options forma parte de la programacion orientada a objetos y la herencia,  los parametros de ApplicationDBContext options base se van a heredar tambien base options
        {
            
        }

        // DBSets 
    }
}
