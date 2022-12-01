using Microsoft.AspNetCore.Mvc;
using TunisBrandCo.Application.Features.Client;
using TunisBrandCo.Application.Features.Order;
using TunisBrandCo.Domain.Features.Clients;
using TunisBrandCo.Infra.Data.Features.Clients;

namespace TunisBrandCo.API.Controllers.Features.Clients
{
    [ApiController]
    [Route("api/Client")]

    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly ClientService _clientService;
        
        public ClientController()
        {
            _clientRepository = new ClientRepository();
            _clientService = new ClientService(_clientRepository);
        }

        [HttpPost]
        public IActionResult PostClient([FromBody] Client newClient)
        {
            return Ok(_clientService.AddClient(newClient));
        }

        [HttpDelete("{cpf}")]
        public IActionResult DeleteClient(string cpf)
        {
            return Ok(_clientService.DeleteClient(cpf));
        }

        [HttpPut]
        public IActionResult PutClient(Client editedClient)
        {
            return Ok(_clientService.UpdateClient(editedClient));
        }

        [HttpGet]
        public IActionResult GetClient()
        {
            return Ok(_clientRepository.GetAllClients());
        }

    }
}
