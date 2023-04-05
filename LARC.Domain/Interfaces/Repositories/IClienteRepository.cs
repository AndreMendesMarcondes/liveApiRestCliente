using LARC.Domain.Domain;

namespace LARC.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task Add(Cliente cliente);
        Task<List<Cliente>> GetAll();
    }
}
