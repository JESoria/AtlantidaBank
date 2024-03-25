using AtlantidaBankAPI.Models.Parameters;
using FluentValidation;

namespace AtlantidaBankAPI.Models.Validations
{
    public class TransactionsValidator : AbstractValidator<TransactionsModel>
    {
        public TransactionsValidator() 
        {
            RuleFor(x => x.TransactionDate).NotEmpty().WithMessage("El campo Fecha de Transacción es requerido");

            RuleFor(x => x.IPAddress).NotEmpty().WithMessage("El campo de Dirección IP es requerido");

            RuleFor(x => x.CrediCardId).NotEmpty().WithMessage("El campo Id de la Tarjeta de credito es requerido");

            RuleFor(x => x.Description).NotEmpty().WithMessage("El campo de Descripción es requerido");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("El campo Amount es requerido")
                .Must(BeValidPositiveNumber).WithMessage("El campo de Monto debe ser un número mayor que cero");
        }

        private bool BeValidPositiveNumber(string value)
        {
            return decimal.TryParse(value, out decimal amount) && amount > 0;
        }
    }
}
