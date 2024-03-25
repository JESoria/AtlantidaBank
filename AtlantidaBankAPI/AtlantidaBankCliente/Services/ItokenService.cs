using AtlantidaBankCliente.Models;
using AtlantidaBankCliente.Models.ViewModels;

namespace AtlantidaBankCliente.Services
{
    public interface ItokenService
    {
        Task<TokenModel> GetToken(LoginViewModel model);
    }
}
