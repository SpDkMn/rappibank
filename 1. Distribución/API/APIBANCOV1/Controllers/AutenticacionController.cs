using Autenticacion;
using BancoEntity;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIBANCOV1.Controllers
{
    [Route("banco/api/v1/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly string secretKey;
        private readonly IAutenticacionService _autenticacionService;
        public AutenticacionController(IConfiguration config, IAutenticacionService autenticacionService)
        {
            secretKey = config.GetSection("Setting").GetSection("SecretKey").ToString();
            _autenticacionService = autenticacionService;
        }

        [HttpPost]
        [Route("validacion")]
        public ActionResult Validation([FromBody] AuthBE request)
        {
            AuthEntity? auth = _autenticacionService.validateAuth(request.Usuario, request.Password);
            if (auth != null)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Usuario));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(90),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                String tokenCreado = tokenHandler.WriteToken(tokenConfig);
                return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado, id = auth.AuthId, Usuario = auth.Usuario });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "", id = 0, admin = "", email = "" });
            }
        }
    }
}
