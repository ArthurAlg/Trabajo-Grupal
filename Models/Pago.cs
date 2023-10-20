using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabajo_Grupal.Models
{
    [Table("t_pago")]
    public class Pago
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? NombreTarjeta { get; set; }

        public string? NumeroTarjeta { get; set; }

        [NotMapped]
        public string? DueDateYYMM { get; set; }
        [NotMapped]
        public string? Cvv { get; set; }
        public Decimal MontoTotal{ get; set; }
        public string? UserID{ get; set; }
    }
}