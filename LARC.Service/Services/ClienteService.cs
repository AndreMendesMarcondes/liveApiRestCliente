using LARC.Domain.Domain;
using LARC.Domain.Interfaces.Repositories;
using LARC.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace LARC.Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ILogger<ClienteService> _log;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(ILogger<ClienteService> log,
                              IClienteRepository clienteRepository)
        {
            _log = log;
            _clienteRepository = clienteRepository;
        }

        public async Task Add(Cliente cliente)
        {
            _log.LogInformation("Service add cliente");

            try
            {
                await _clienteRepository.Add(cliente);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Erro ao chamar service add cliente");
                throw;
            }
        }

        public async Task<List<Cliente>> GetAll()
        {
            _log.LogInformation("Service GetAll cliente");

            try
            {
                var listaClientes = await _clienteRepository.GetAll();
                return listaClientes;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Erro ao chamar service GetAll cliente");
                throw;
            }
        }
    }
}
