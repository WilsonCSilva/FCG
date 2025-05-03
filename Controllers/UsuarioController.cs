using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController(IConfiguration configuratios, BaseLogger<UsuarioController> Logger) : ControllerBase
    {
        //private readonly IConfiguration _configuration = configuratios;
        //private readonly BaseLogger<UsuarioController> _logger = Logger;

        //[HttpGet("usuarios")]

    }
}
