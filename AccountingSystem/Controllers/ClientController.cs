using AccountingSystem.Repositories.Interfaces;
using System.Web.Mvc;

namespace AccountingSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _repository;

        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var clients = _repository.GetClients();

            return View(clients);
        }
    }
}
