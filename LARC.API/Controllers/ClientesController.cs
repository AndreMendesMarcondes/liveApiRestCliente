using LARC.Domain.Domain;
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
            _log.LogInformation("Controller getclientes");

            try
            {
                var listaClientes = await _clienteService.GetAll();
                return Ok(listaClientes);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Erro ao chamar controller getclientes");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente(Cliente cliente)
        {
            _log.LogInformation("Controller AddCliente");

            try
            {
                await _clienteService.Add(cliente);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Erro ao chamar controller AddCliente");
                throw;
            }
        }
    }
}
