using FCG.Infrastructure.Repository.Helpers;
using FCG.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Controllers
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
                var token = GerarToken(userName, "admin");
                _logger.LogInfotmation("Token gerado com sucesso.");
                return Ok(new { token });
            }
            else if (userName == "user" && password == "user")
            {
                var token = GerarToken(userName, "user");
                _logger.LogInfotmation("Token gerado com sucesso.");
                return Ok(new { token });
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
    }
}
