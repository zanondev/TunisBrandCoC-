using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TunisBrandCo.Domain.Features.Clients
{
    public interface IClientRepository
    {
        void AddClient(Client newClient);
        void UpdateClient(Client editedClient);
        void DeleteClient(int clientId);
        public List<Client> GetAllClients();
        public Client GetClientByCpf(string cpf);
        Client GetClientById(int clientId);
    }
}
