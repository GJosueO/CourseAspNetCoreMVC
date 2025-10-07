using System.ComponentModel.DataAnnotations;

namespace CrudNet9MVC.Models
{
    public class Contacto
    {
        [Key] //Recomendable usar si no se describe como tal
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")] //Validacion por parte del servidor
        public string Nombre { get; set; }
        //Se puede establecer una cantidad min y max
        [Required(ErrorMessage ="El telefono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage ="El celular es obligatorio")]
        public string Celular { get; set; }    
        [Required(ErrorMessage ="El Emal es obligatorio")]
        public string Email { get; set; }    
        
        public DateTime FechaCreacion {  get; set; }
    }
}
