using System.ComponentModel.DataAnnotations;

namespace AtlantidaBankCliente.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El usuario es requerido.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El contraseña es requerida.")]
        public string Password { get; set; }
    }
}
