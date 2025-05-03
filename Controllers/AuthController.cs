using FCG.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FIAPCloudGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IConfiguration configuration, BaseLogger<AuthController> logger) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly BaseLogger<AuthController> _logger = logger;

        [HttpPost("login")]
        public IActionResult Logar(string userName, string password)
        {
            if (userName == "admin" && password == "admin")
            {
                var (token, dataCriacao, dataExpiracao) = GerarToken(userName, "admin");
                
                _logger.LogInfotmation("Token gerado com sucesso.");
                
                return Ok(new
                {
                    token,
                    type = "Bearer",
                    iat = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expires = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss")
                });
            }
            else if (userName == "user" && password == "user")
            {
                var (token, dataCriacao, dataExpiracao) = GerarToken(userName, "user");
                
                _logger.LogInfotmation("Token gerado com sucesso.");
                
                return Ok(new
                {
                    token,
                    type = "Bearer",
                    iat = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expires = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss")
                });
            }
            else
            {
                var erroResponse = new ErroResponse
                {
                    StatusCode = 401,
                    Erro = "Unauthorized",
                    Detalhe = "Usuário ou senha inválidos."
                };
                
                _logger.LogError("Erro ao gerar token.");
                
                return Unauthorized(erroResponse);
            }
        }

        private (string token, DateTime dataCriacao, DateTime dataExpiracao) GerarToken(string userName, string role)
        {
            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao.AddMinutes(double.Parse(_configuration["JWT:ExpirationMinutes"]));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Email, userName),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Iat, dataCriacao.ToString("yyyy-MM-dd HH:mm:ss")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: dataExpiracao,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return (tokenString, dataCriacao, dataExpiracao);
        }
    }
}
