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
        
        [Required(ErrorMessage = "El nombre de la tarjeta es obligatorio.")]
        [Display(Name = "Nombre de Tarjeta")]
        public string? NombreTarjeta { get; set; }

        [Required(ErrorMessage = "El número de tarjeta es obligatorio.")]
        [Display(Name = "Número de Tarjeta")]
        [CreditCard(ErrorMessage = "Por favor, ingrese un número de tarjeta válido.")]
        public string? NumeroTarjeta { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        [Display(Name = "Fecha de Vencimiento (yy/mm)")]
        [RegularExpression(@"^\d{2}/\d{2}$", ErrorMessage = "Formato de fecha de vencimiento no válido. Use el formato 'yy/mm'.")]
        [NotMapped]
        public string? DueDateYYMM { get; set; }
        
        [Required(ErrorMessage = "El CVV es obligatorio.")]
        [Display(Name = "CVV")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "El CVV debe tener 3 dígitos.")]
        
        [NotMapped]
        public string? Cvv { get; set; }
        public Decimal MontoTotal{ get; set; }
        public string? UserID{ get; set; }
    }
}