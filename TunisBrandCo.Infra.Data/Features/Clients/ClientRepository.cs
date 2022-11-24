using System;
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
    }
}
