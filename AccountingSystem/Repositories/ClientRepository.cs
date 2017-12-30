using AccountingSystem.Repositories.Interfaces;
using AccountingSystem.Contexts.Interfaces;
using AccountingSystem.Models.FrontendModels;
using System.Collections.Generic;
using System.Linq;

namespace AccountingSystem.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private IDbContext _dbContext;

        public ClientRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ClientCardViewModel GetClient(int id)
        {
            var client = _dbContext.GetClient(id);
            var totalAmount = _dbContext.GetTotalAmount(id);

            return client.MapToClientCardViewModel(client, totalAmount);
        }

        public IEnumerable<ClientViewModel> GetClients()
        {
            return _dbContext.GetClients().Select(client => client.MapToClientViewModel(client));
        }

        public IEnumerable<ClientViewModel> GetFilteredClients(string filter)
        {
            return _dbContext.GetClients(filter).Select(client => client.MapToClientViewModel(client));
        }
    }
}