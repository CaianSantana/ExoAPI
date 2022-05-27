using Exoapi.Interfaces;
using Exoapi.Models;
using Exoapi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Exoapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IFuncionarioRepository _iFuncionarioRepository;

        public LoginController(IFuncionarioRepository funcionarioRepository)
        {
            _iFuncionarioRepository = funcionarioRepository;
        }

        [HttpPost]
        
        public IActionResult Login(LoginViewModel login)
        {
            Funcionario funcionarioEncontrado = _iFuncionarioRepository.Login(login.Email, login.Senha);

            if(funcionarioEncontrado == null)
            {
                return Unauthorized(new {msg = "E-mail e/ou senha invalido(s)"});
            }

            var minhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, funcionarioEncontrado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, funcionarioEncontrado.IDFuncionario.ToString()),
                new Claim(ClaimTypes.Role, funcionarioEncontrado.Nivel)
            };

            var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Exoapi-chave-autenticacao"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var meuToken = new JwtSecurityToken
                (
                    issuer: "Exoapi.webapi",
                    audience: "Exoapi.webapi",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credenciais
                );
            return Ok(
                new {token = new JwtSecurityTokenHandler().WriteToken(meuToken) }
                );
        }
    }
}
