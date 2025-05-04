using FCG.Infrastructure.Repository.Helpers;
using FCG.Interfaces;
using FCG.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController(IUsuarioRepository usuarioRepository, CriptografiaHelper criptografiaHelper, TextoHelper textoHelper, BaseLogger<UsuarioController> Logger) : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly BaseLogger<UsuarioController> _logger = Logger;
        private readonly CriptografiaHelper _criptografiaHelper = criptografiaHelper;
        private readonly TextoHelper _textoHelper = textoHelper;


        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                var _usuario = new Usuario()
                {
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = _criptografiaHelper.Criptografar(usuario.Senha),
                    DataNascimento = usuario.DataNascimento
                };

                bool emailValido = _textoHelper.EmailValido(_usuario.Email);
                bool senhaValida = _textoHelper.SenhaValida(_criptografiaHelper.Descriptografar(_usuario.Senha));

                if (!emailValido)
                {
                    string erroResponse = "Email inválido.";
                    _logger.LogError(erroResponse);
                    return BadRequest(erroResponse);
                }
                else if (!senhaValida)
                {
                    string erroResponse = "Senha inválida.";
                    _logger.LogError(erroResponse);
                    return BadRequest(erroResponse);
                }
                else
                {
                    _usuarioRepository.Cadastrar(_usuario);
                    string okResponse = $"Usuário {_usuario.Id} cadastrado com sucesso.";
                    _logger.LogInfotmation(okResponse);
                    return Ok(okResponse);
                }

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

        [HttpGet("todos")]
        public IActionResult Get()
        {
            try
            {
                var _usuarios = _usuarioRepository.ObterTodos();
                _logger.LogInfotmation("Todos os usuários exibidos com sucesso.");
                return Ok(_usuarios);
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

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var _usuario = _usuarioRepository.ObterPorID(id);
                if (_usuario == null)
                {
                    var erroResponse = new ErroResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Erro = "Not Found",
                        Detalhe = "Usuário não encontrado."
                    };
                    _logger.LogError(erroResponse.ToString());
                    return NotFound(erroResponse);
                }
                _logger.LogInfotmation($"Usuário {id} exibido com sucesso.");
                return Ok(_usuario);
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

        [HttpPut]
        public IActionResult Put([FromBody] Usuario usuario)
        {
            try
            {
                var _usuario = _usuarioRepository.ObterPorID(usuario.Id);
                {
                    _usuario.Nome = usuario.Nome;
                    _usuario.Email = usuario.Email;
                    _usuario.Senha = usuario.Senha;
                    _usuario.DataNascimento = usuario.DataNascimento;
                }
                ;
                _usuarioRepository.Alterar(_usuario);

                string okResponse = $"Usuário {usuario.Id} alterado com sucesso.";
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

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

                string okResponse = $"Usuário {id} excluído com sucesso.";
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
