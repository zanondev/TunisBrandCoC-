using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TunisBrandCo.Domain.Features.Clients;
using TunisBrandCo.Infra.Data.Features.Clients;
using TunisBrandCo.Application.Features.Client;



namespace TunisBrandCo.API.Controllers
{
    [ApiController]
    [Route("api/clientes")]

    public class ClentController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly ClientService clientService;

        public ClentController()
        {
            _clientRepository = new ClientRepository();
        }

        [HttpPost]
        public IActionResult PostClient(Client newClient)
        {
            return Ok(clientService.AddClient(newClient));
        }

        [HttpDelete("{cpf}")]
        public IActionResult DeleteClient(string cpf)
        {
            return Ok(clientService.DeleteClient(cpf));
        }
    }
}
