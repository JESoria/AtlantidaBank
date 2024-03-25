using AtlantidaBankAPI.Models.DTOs;
using AtlantidaBankAPI.Models.Parameters;

namespace AtlantidaBankAPI.Services
{
    public interface ITokenService
    {
        //public string GenerateToken(LoginModel model);
        public Task<UserDTO> ValidateUser(LoginModel login);
    }
}
