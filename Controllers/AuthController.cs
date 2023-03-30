using ApiReverseEngineering.Interfaces;
using ApiReverseEngineering.Models;
using ApiReverseEngineering.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiReverseEngineering.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        IAuth auth;
        private readonly ILogger<ClientController> _logger;
        IConfiguration configuration;
        public AuthController(IAuth authServices, IConfiguration configuration, ILogger<ClientController> logger)
        {
            auth = authServices;
            _logger = logger;
            this.configuration = configuration;
        }
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Login(AuthModel authModel)
        {
            var user = await auth.Get(authModel);
            if (user == null)
            {
                return NotFound(new { message = "Usuario o credenciales invalidas." });
            }
            string jwtToken = GenerateToken(authModel);
            return Ok(new { token = jwtToken });

        }

        private string GenerateToken(AuthModel authModel)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.UserData, authModel.User),
                 new Claim(ClaimTypes.Authentication, authModel.Password )
            };
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.GetSection("JWT:key").Value));
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials
                );
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
