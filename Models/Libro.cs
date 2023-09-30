using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_Grupal.Models
{
    [Table("t_libros")]
    public class Libro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public string? Nombre { get; set;}
        public string? Categoria { get; set;}
        public string? Descripcion { get; set;}
        public string? Autor { get; set;}
        public decimal? Precio { get; set;}
        public decimal Descuento { get; set;}
        public string? Status { get; set;}
        public string? ImageName { get; set; }
    }

}