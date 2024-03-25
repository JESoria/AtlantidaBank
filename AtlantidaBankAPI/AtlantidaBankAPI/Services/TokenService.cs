using AtlantidaBankAPI.Models.DTOs;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AtlantidaBankAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ganss.Xss;
using AutoMapper;
using AtlantidaBankAPI.Models.Parameters;

namespace AtlantidaBankAPI.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _config;
        private readonly HtmlSanitizer _htmlSanitizer;
        private readonly TokenService _tokenService;
        private readonly AtlantidaBankContext _context;
        private readonly IMapper _mapper;

        public TokenService(IConfiguration config, HtmlSanitizer htmlSanitizer,AtlantidaBankContext _context, IMapper mapper)
        {
            this._config = config;
            this._htmlSanitizer = htmlSanitizer;
            this._context = _context;
            this._mapper = mapper;
        }

        public async Task<UserDTO> ValidateUser(LoginModel login)
        {
            var _claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, login.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var securityToken = new JwtSecurityToken(
                    claims: _claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials
                );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            login.Username = _htmlSanitizer.Sanitize(login.Username);
            login.Password = _htmlSanitizer.Sanitize(login.Password);

            var usernameParameter = new SqlParameter("@username", login.Username);
            var passwordParameter = new SqlParameter("@password", login.Password);

            var IsUserValid = await _context.Set<SP_Login>().FromSqlRaw("EXEC SP_Login @username, @password", usernameParameter, passwordParameter).ToListAsync();

            if (IsUserValid.Count == 0)
            {
                return new UserDTO();
            }

            var mUser = _mapper.Map<UserDTO>(IsUserValid.FirstOrDefault());

            mUser.token = token;

            return mUser;
        }

    }
}
