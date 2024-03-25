using AtlantidaBankCliente.Models;

namespace AtlantidaBankCliente.Services
{
    public interface ISessionService
    {
        void SaveSession(TokenModel model);
        TokenModel GetSession();

        void CloseSession();
    }
}
