using BlogCoreSolution.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogCoreSolution.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext //Se hereda y el codigo es mas legible, porque queda la clase que envuelve todo
    {
        //Creacion de constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :  //Dentro tenemos el constructor la clase que hereda a dbcontext
            base (options) // Codigo que siempre se coloca define que el constructor se esta pasando a IdentityDBContext gracias al base options
        {
        }

        //IRAN LOS DBSET DE LAS ENTIDADES
        public DbSet<Categoria> Categorias { get; set; }
    }

}
