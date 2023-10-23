using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_Grupal.Models
{
    [Table("t_mi_lista")]
    public class MiLista
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]        
        public int Id { get; set; }
        public string? imgProducto { get; set; }   
        public Producto? Producto { get; set; }
        public Decimal Precio { get; set; }
        public string? UserID { get; set; }
    }
    
}