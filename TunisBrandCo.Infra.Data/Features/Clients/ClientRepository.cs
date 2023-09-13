using System;
using System.Collections.Generic;
using TunisBrandCo.Domain.Features.Clients;

namespace TunisBrandCo.Infra.Data.Features.Clients
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientDAO _clientDAO;

        public ClientRepository()
        {
            _clientDAO = new ClientDAO();
        }
        public void AddClient(Client newClient)
        {
            _clientDAO.AddClient(newClient);
        }

        public void DeleteClient(int clientId)
        {
            _clientDAO.DeleteCliente(clientId);
        }

        public void UpdateClient(Client editedClient)
        {
            _clientDAO.UpdateClient(editedClient);
        }
        public void UpdateLoyaltyPoints(int clientId, decimal points)
        {
            _clientDAO.UpdateLoyaltyPoint(clientId, points);
        }

        public List<Client> GetAllClients()
        {
           return _clientDAO.GetAllClients();
        }

        Client IClientRepository.GetClientByCpf(string cpf)
        {
            return _clientDAO.GetClientByCpf(cpf);
        }

        public Client GetClientById(int clientId)
        {
            return _clientDAO.GetClientById(clientId);
        }
    }
}
