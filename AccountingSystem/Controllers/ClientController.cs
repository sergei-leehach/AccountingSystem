using AccountingSystem.Models.FrontendModels;
using AccountingSystem.Repositories.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace AccountingSystem.Controllers
{
    public class ClientController : ApiController
    {     
        private readonly IClientRepository _repository;

        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        [Route("api/Clients")]
        public IEnumerable<ClientViewModel> GetClients()
        {
            var clients = _repository.GetClients();

            return clients;
        }

        [Route("api/Clients/{filter}")]
        public IEnumerable<ClientViewModel> GetClients(string filter)
        {
            var clients = _repository.GetFilteredClients(filter);

            return clients;
        }

        [Route("api/Client/{id}")]
        public ClientCardViewModel GetClient(int id)
        {
            var client = _repository.GetClient(id);

            return client;
        }
    }
}
