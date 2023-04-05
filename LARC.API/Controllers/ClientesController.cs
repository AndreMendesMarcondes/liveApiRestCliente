using LARC.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LARC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _log;
        private readonly IClienteService _clienteService;

        public ClientesController(ILogger<ClientesController> log,
                                  IClienteService clienteService)
        {
            _log = log;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            return Ok("teste cliente");
        }
    }
}
