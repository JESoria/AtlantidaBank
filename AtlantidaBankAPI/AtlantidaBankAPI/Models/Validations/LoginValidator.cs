using AtlantidaBankAPI.Models.Parameters;
using FluentValidation;

namespace AtlantidaBankAPI.Models.Validations
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator() 
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("El campo Usuario es requerido");

            RuleFor(x => x.Password).NotEmpty().WithMessage("El campo Contraseña es requerido");
        }

    }
}
