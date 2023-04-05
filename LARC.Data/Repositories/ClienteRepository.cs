using LARC.Domain.Domain;
using LARC.Domain.Interfaces.Repositories;
using LARC.Domain.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LARC.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<Cliente> _collection;
        private readonly ILogger<ClienteRepository> _log;
        private static string CollectionName = "cliente";

        public ClienteRepository(ILogger<ClienteRepository> log,
                                 IOptions<MongoDbSettings> mongoSettings)
        {
            _log = log;
            var mongoClient = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(mongoSettings.Value.DatabaseName);
            _collection = database.GetCollection<Cliente>(CollectionName);
        }

        public async Task Add(Cliente cliente)
        {
            _log.LogInformation("Adicionando cliente ao repositorio");

            try
            {
                await _collection.InsertOneAsync(cliente);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Erro ao adicionar cliente ao repositorio");
                throw;
            }
        }

        public async Task<List<Cliente>> GetAll()
        {
            _log.LogInformation("Buscando cliente no repositorio");

            try
            {
                var listaClientes = await _collection.FindAsync(c => true);
                return listaClientes.ToList();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Erro ao buscar cliente no repositorio");
                throw;
            }
        }
    }
}
