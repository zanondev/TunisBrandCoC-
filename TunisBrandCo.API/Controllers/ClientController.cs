using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TunisBrandCo.Domain.Features.Clients;
using TunisBrandCo.Infra.Data.Features.Clients;
using TunisBrandCo.Application.Features.Client;
using Microsoft.Extensions.Logging;



namespace TunisBrandCo.API.Controllers
{
    [ApiController]
    [Route("api/clientes")]

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
    }
}
