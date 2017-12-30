using AccountingSystem.Models.FrontendModels;
using System.Collections.Generic;

namespace AccountingSystem.Repositories.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<ClientViewModel> GetClients();
        IEnumerable<ClientViewModel> GetFilteredClients(string filter);
        ClientCardViewModel GetClient(int id);
    }
}
