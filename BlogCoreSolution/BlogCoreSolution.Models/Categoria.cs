using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogCoreSolution.Models
{
    public class Categoria
    {
        public Categoria()
        {
            FechaCreacion = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(60)]
        [Display(Name = "Nombre de categoría")]
        public string? Nombre { get; set; }
        [Display(Name = "Orden de visualización")]
        [Range(1,100, ErrorMessage = "El valor debe estar entre el 1 y 100")]
        public int Orden { get; set; }
        [Display(Name = "Fecha de Creacion")]
        public DateTime FechaCreacion { get; set; }
        



    }
}
