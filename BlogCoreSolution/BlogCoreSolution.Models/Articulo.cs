using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogCoreSolution.Models
{
    public class Articulo
    {
        public Articulo()
        {
            FechaCreacion = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del articulo es requerido")]
        [Display(Name ="Nombre del articulo:")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion del articulo es requerida")]
        [Display(Name = "Descripcion:")]
        public string Descripcion { get; set; }
        [Display(Name = "Fecha de creacion:")]
        public DateTime FechaCreacion { get; set; }
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen:")]
        public string UrlImagen { get; set; }
        [Required(ErrorMessage = "La categoria del articulo es requerida")]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

    }
}
