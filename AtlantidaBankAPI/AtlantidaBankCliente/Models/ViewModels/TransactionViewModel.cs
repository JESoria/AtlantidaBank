using System.ComponentModel.DataAnnotations;

namespace AtlantidaBankCliente.Models.ViewModels
{
    public class TransactionViewModel
    {
        public string Message { get; set; }
        public string CrediCardId { get; set; }

        [Required(ErrorMessage = "La fecha de la transacción es requerida.")]
        [Display(Name = "Fecha de Transacción")]
        public string TransactionDate { get; set; }

        [Required(ErrorMessage = "La descripción de la compra es requerida.")]
        [Display(Name = "Descripción de la Compra")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El monto de la compra es requerida.")]
        [Display(Name = "Monto de la Compra")]
        public string Amount { get; set; }
        public string IPAddress { get; set; }
    }
}
