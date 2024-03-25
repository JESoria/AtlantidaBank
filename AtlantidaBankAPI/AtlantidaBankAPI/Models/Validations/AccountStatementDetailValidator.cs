using AtlantidaBankAPI.Models.Parameters;
using FluentValidation;

namespace AtlantidaBankAPI.Models.Validations
{
    public class AccountStatementDetailValidator : AbstractValidator<AccountStatementDetailModel>
    {
        public AccountStatementDetailValidator() 
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("El campo Id de Usuario es requerido");

            RuleFor(x => x.CrediCardId).NotEmpty().WithMessage("El campo Id de la tarjeta de credito es requerido");
        }
    }
}
