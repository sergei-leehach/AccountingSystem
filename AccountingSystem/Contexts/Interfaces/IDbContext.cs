using AccountingSystem.Models;
using System.Collections.Generic;

namespace AccountingSystem.Contexts.Interfaces
{
    public interface IDbContext
    {
        IEnumerable<Client> GetClients(string filter = "");
        Client GetClient(int id);
        decimal GetTotalAmount(int id);
    }
}
