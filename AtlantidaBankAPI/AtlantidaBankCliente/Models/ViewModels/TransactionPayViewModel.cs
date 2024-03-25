using System.ComponentModel.DataAnnotations;

namespace AtlantidaBankCliente.Models.ViewModels
{
    public class TransactionPayViewModel
    {
        public string Message { get; set; }
        public string CrediCardId { get; set; }

        [Required(ErrorMessage = "La fecha de pago es requerida.")]
        [Display(Name = "Fecha de Transacción")]
        public string TransactionDate { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "El monto de la compra es requerida.")]
        [Display(Name = "Monto de la Compra")]
        public string Amount { get; set; }
        public string IPAddress { get; set; }
    }
}
