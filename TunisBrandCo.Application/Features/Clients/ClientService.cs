using Azure.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Clients;
using TunisBrandCo.Domain.Exceptions;
using TunisBrandCo.Infra.Data.Features.Clients;
using Azure;
using System.Net;

namespace TunisBrandCo.Application.Features.Client
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = new ClientRepository();
        }

        public Domain.Features.Clients.Client AddClient(Domain.Features.Clients.Client newClient)
        {
            if (newClient == null)
                throw new NotFoundException($"Client: {newClient.Cpf} doesn't exists.");

            var clientList = _clientRepository.GetAllClients();
            foreach (var client in clientList)
            {
                if (client.Cpf == newClient.Cpf)
                    throw new AlreadyExistsException($"Client CPF: {newClient.Cpf} already exists.");
            }

            _clientRepository.AddClient(newClient);

            return newClient;
        }

        public string DeleteClient(string cpf)
        {
            var client = _clientRepository.GetClientByCpf(cpf);

            if (client.Cpf == null)
                throw new NotFoundException($"Client: {client.Cpf} doesn't exists.");

            _clientRepository.DeleteClient(client.Id);

            return "Cliente deletado com sucesso!";
        }


        public string UpdateClient(Domain.Features.Clients.Client editedClient)
        {
            var client = _clientRepository.GetClientById(editedClient.Id);

            if ((client.Id != editedClient.Id) || editedClient == null)
                throw new NotFoundException($"Client: {client.Cpf} doesn't exists.");
            
            client.Cpf = editedClient.Cpf;
            client.BirthDate = editedClient.BirthDate;
            client.Name = editedClient.Name;

            _clientRepository.UpdateClient(client);

            return "Cliente alterado com sucesso!";
        }










    }
}
