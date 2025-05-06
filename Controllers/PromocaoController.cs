using FCG.Interfaces;
using FCG.Middlewares;
using FCG.Models;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromocaoController(IPromocaoRepository promocaoRepository, BaseLogger<PromocaoController> logger) : ControllerBase
    {
        private readonly IPromocaoRepository _promocaoRepository = promocaoRepository;
        private readonly BaseLogger<PromocaoController> _logger = logger;

        [HttpPost]
        public IActionResult Post([FromBody] Promocao promocao)
        {
            try
            {
                var _promocao = new Promocao()
                {
                    DataInicioPromocao = promocao.DataInicioPromocao,
                    DataFimPromocao = promocao.DataFimPromocao,
                };
                _promocaoRepository.Cadastrar(_promocao);
                string okResponse = $"Promoção {_promocao.Id} cadastrada com sucesso.";
                _logger.LogInfotmation(okResponse);
                return Ok(okResponse);
            }
            catch (Exception ex)
            {
                var erroResponse = new ErroResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Erro = "Bad Request",
                    Detalhe = ex.Message
                };
                _logger.LogError(erroResponse.ToString());
                return BadRequest(erroResponse);
            }
        }
    }
}
