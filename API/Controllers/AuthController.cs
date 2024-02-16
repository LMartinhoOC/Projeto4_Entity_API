using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projeto4.API.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Projeto4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        private string TokenGenerator()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("Key:JwtKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //informações da entidade tratada. normalmente o usuário autenticado
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim("Store", "admin"),
                    new Claim(ClaimTypes.Role, "admin")
                }),
                Issuer = "Waldir Lima Editora Ltda", //Emissor do token
                Audience = "https://localhost:7273", //Destinatário do token, representa a aplicação que irá usá-lo.
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (model.login == "admin" &&
                    model.password == "admin")
                {
                    TokenViewModel tokenModel = new TokenViewModel();
                    tokenModel.token = TokenGenerator();
                    return Ok(tokenModel);
                }
                else
                {
                    return BadRequest("Login ou senha inválidos!");
                }
            }
        }
    }
}
