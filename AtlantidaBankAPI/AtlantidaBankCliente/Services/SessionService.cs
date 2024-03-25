using AtlantidaBankCliente.Models;

namespace AtlantidaBankCliente.Services
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public SessionService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public TokenModel GetSession()
        {
            TokenModel session = new TokenModel();

            session.UserId = _contextAccessor.HttpContext.Session.GetInt32("UserId").Value;
            session.CrediCardId = _contextAccessor.HttpContext.Session.GetInt32("CrediCardId").Value;
            session.FirstName = _contextAccessor.HttpContext.Session.GetString("FirstName");
            session.LastName = _contextAccessor.HttpContext.Session.GetString("LastName");
            session.Email = _contextAccessor.HttpContext.Session.GetString("Email");
            session.Token = _contextAccessor.HttpContext.Session.GetString("Token");
            session.IPAddress = _contextAccessor.HttpContext.Session.GetString("IPAddress");

            return session;
        }

        public void SaveSession(TokenModel model)
        {
            _contextAccessor.HttpContext.Session.SetInt32("UserId", model.UserId);
            _contextAccessor.HttpContext.Session.SetInt32("CrediCardId", model.CrediCardId);
            _contextAccessor.HttpContext.Session.SetString("FirstName", model.FirstName.ToString());
            _contextAccessor.HttpContext.Session.SetString("LastName", model.LastName.ToString());
            _contextAccessor.HttpContext.Session.SetString("Email", model.Email.ToString());
            _contextAccessor.HttpContext.Session.SetString("Token", model.Token.ToString());
            _contextAccessor.HttpContext.Session.SetString("IPAddress", ObtenerDireccionIP());
        }

        public void CloseSession()
        {
            _contextAccessor.HttpContext.Session.Remove("UserId");
            _contextAccessor.HttpContext.Session.Remove("CrediCardId");
            _contextAccessor.HttpContext.Session.Remove("FirstName");
            _contextAccessor.HttpContext.Session.Remove("LastName");
            _contextAccessor.HttpContext.Session.Remove("Email");
            _contextAccessor.HttpContext.Session.Remove("Token");
            _contextAccessor.HttpContext.Session.Remove("IPAddress");
        }

        public string ObtenerDireccionIP()
        {
            var ipAddress = _contextAccessor.HttpContext.Connection.RemoteIpAddress;

            if (ipAddress != null)
            {
                if (ipAddress.IsIPv4MappedToIPv6)
                {
                    ipAddress = ipAddress.MapToIPv4();
                }

                return ipAddress.ToString();
            }

            return "Dirección IP no disponible";
        }

    }
}
