using LARC.Domain.Domain;

namespace LARC.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task Add(Cliente cliente);
        Task<List<Cliente>> GetAll();
    }
}
