using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabajo_Grupal.Models
{
   [Table("t_product")]
    public class Producto
    {  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name {get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set;} 

        [Column("autor")]
        public string? Autor { get; set;}

        [Column("genero")]
        public string? Genero { get; set;}

        [Column("idioma")]
        public string? Idioma { get; set;}

        [Column("editorial")]
        public string? Editorial { get; set;} 

        [Column("año")]
        public int año { get; set; }

        [Column("n_pag")]
        public int Npag { get; set; }
        public string? ImageName { get; set;}

        [Column("precio")]
        public Decimal Precio { get; set;}

        [Column("descuento")]
        public Decimal Descuento { get; set;}

    }
}
