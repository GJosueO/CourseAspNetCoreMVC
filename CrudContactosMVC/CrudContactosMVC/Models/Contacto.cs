using System.ComponentModel.DataAnnotations;

namespace CrudContactosMVC.Models
{
    public class Contacto
    {
        [Key]
        public int Id{ get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracters.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo no es valido.")]
        [StringLength(150)]
        public string  Correo{ get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio.")]
        [Phone(ErrorMessage = "El formato del telefono no es valido.")]
        [StringLength(20)]
        public string? Telefono { get; set; }
        
        [StringLength(250)]
        public string? Direccion { get; set; }
    }
}
