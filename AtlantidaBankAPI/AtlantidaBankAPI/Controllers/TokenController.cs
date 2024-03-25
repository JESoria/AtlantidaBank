using AtlantidaBankAPI.Models.Parameters;
using AtlantidaBankAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AtlantidaBankAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TokenController : Controller
    {
        private readonly TokenService _tokenService;

        public TokenController(TokenService tokenService)
        {
            this._tokenService = tokenService;
        }

        [HttpPost]
        [Route("GetToken")]
        public async Task<IActionResult> GetToken(LoginModel token)
        {
            if (ModelState.IsValid)
            {
                if (token is not null)
                {
                    var mUser = await _tokenService.ValidateUser(token);

                    if (mUser.token is not null)
                    {
                        return StatusCode(StatusCodes.Status200OK, mUser);
                    }
                    else
                        return StatusCode(StatusCodes.Status401Unauthorized, "Credenciales invalidas");

                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

    }
}
