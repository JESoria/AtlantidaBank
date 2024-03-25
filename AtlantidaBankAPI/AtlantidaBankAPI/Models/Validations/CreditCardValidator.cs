using AtlantidaBankAPI.Models.Parameters;
using FluentValidation;

namespace AtlantidaBankAPI.Models.Validations
{
    public class CreditCardValidator : AbstractValidator<CreditCardModel>
    {
        public CreditCardValidator() 
        {
            RuleFor(x => x.CrediCardId).NotEmpty().WithMessage("El campo Id de la tarjeta de credito es requerido");
        }
    }
}
