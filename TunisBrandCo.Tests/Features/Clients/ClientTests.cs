using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Clients;
using TunisBrandCo.Application.Features.Client;
using TunisBrandCo.Infra.Data.Features.Clients;
using Moq;
using Castle.Components.DictionaryAdapter.Xml;

namespace TunisBrandCo.Tests.Features.Clients
{
    public class ClientTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_ValidateClient_And_NameIsEmptyOrNull_Then_MustBeInvalid()
        {
            //arrange
            var _clientRepository = new Mock<IClientRepository>();

            var client = new Client()
            {
                Id = 1,
                BirthDate = System.DateTime.Now.AddDays(-1),
                LoyaltyPoints = 0,
                Cpf = "00000000000",
            };

            var clientList = new List<Client>();
            _clientRepository.Setup(x => x.GetAllClients()).Returns(clientList);

            _clientRepository.Setup(x => x.AddClient(client));

            var _clientService = new ClientService(_clientRepository.Object);

            //action
            //assert
            Assert.That(() => _clientService.AddClient(client), Throws.Exception);
        }

        [Test]
        public void When_ValidateClient_And_CpfIsEmptyOrNull_Then_MustBeInvalid()
        {
            //arrange
            var _clientRepository = new Mock<IClientRepository>();

            var client = new Client()
            {
                Id = 1,
                BirthDate = System.DateTime.Now.AddDays(-1),
                LoyaltyPoints = 0,
                Name = "Lucas"
            };

            var clientList = new List<Client>();
            _clientRepository.Setup(x => x.GetAllClients()).Returns(clientList);

            _clientRepository.Setup(x => x.AddClient(client));

            var _clientService = new ClientService(_clientRepository.Object);

            //action
            //assert
            Assert.That(() => _clientService.AddClient(client), Throws.Exception);
        }

        [Test]
        public void When_ValidateClient_And_NameHaveLessThan3Characters_Then_MustBeInvalid()
        {
            //arrange
            var _clientRepository = new Mock<IClientRepository>();

            var client = new Client()
            {
                Id = 1,
                BirthDate = System.DateTime.Now.AddDays(-1),
                LoyaltyPoints = 0,
                Cpf = "00000000000",
                Name = "Lu"
            };

            var clientList = new List<Client>();
            _clientRepository.Setup(x => x.GetAllClients()).Returns(clientList);

            _clientRepository.Setup(x => x.AddClient(client));

            var _clientService = new ClientService(_clientRepository.Object);

            //action
            //assert
            Assert.That(() => _clientService.AddClient(client), Throws.Exception);
        }

        [Test]
        public void When_ValidateClient_And_BirthDateIsLessThanCurrentDate_Then_MustBeInvalid()
        {
            //arrange
            var _clientRepository = new Mock<IClientRepository>();

            var client = new Client()
            {
                Id = 1,
                BirthDate = System.DateTime.Now.AddDays(1),
                LoyaltyPoints = 0,
                Cpf = "00000000000",
                Name = "Lucas"
            };

            var clientList = new List<Client>();
            _clientRepository.Setup(x => x.GetAllClients()).Returns(clientList);

            _clientRepository.Setup(x => x.AddClient(client));

            var _clientService = new ClientService(_clientRepository.Object);

            //action
            //assert
            Assert.That(() => _clientService.AddClient(client), Throws.Exception);
        }

        [Test]
        public void When_ValidateClient_And_CpfHaveMoreThan11Characters_Then_MustBeInvalid()
        {
            //arrange
            var _clientRepository = new Mock<IClientRepository>();

            var client = new Client()
            {
                Id = 1,
                BirthDate = System.DateTime.Now.AddDays(-1),
                LoyaltyPoints = 0,
                Cpf = "000000000000",
                Name = "Lucas"
            };

            var clientList = new List<Client>();
            _clientRepository.Setup(x => x.GetAllClients()).Returns(clientList);

            _clientRepository.Setup(x => x.AddClient(client));

            var _clientService = new ClientService(_clientRepository.Object);

            //action
            //assert
            Assert.That(() => _clientService.AddClient(client), Throws.Exception);
        }

        [Test]
        public void When_AddClient_And_AllDataIsOk_Then_MustBeValid()
        {
            //arrange
            var _clientRepository = new Mock<IClientRepository>();

            var client = new Client()
            {
                Id = 1,
                BirthDate = System.DateTime.Now.AddDays(-1),
                LoyaltyPoints = 0,
                Cpf = "00000000000",
                Name = "Lucas"
            };

            var clientList = new List<Client>();
            _clientRepository.Setup(x => x.GetAllClients()).Returns(clientList);

            _clientRepository.Setup(x => x.AddClient(client));

            var _clientService = new ClientService(_clientRepository.Object);

            //action
            //assert
            Assert.That(() => _clientService.AddClient(client), Throws.Nothing);
        }

        [Test]
        public void When_GetAllClients_MustWorks()
        {
            //arrange
            var _clientRepository = new ClientRepository();

            //action
            //assert
            Assert.That(() => _clientRepository.GetAllClients(), Throws.Nothing);
        }

        [Test]
        public void When_DeteleClient_MustWorks()
        {
            //arrange
            var _clientRepository = new Mock<IClientRepository>();

            var client = new Client()
            {
                Id = 1,
                BirthDate = System.DateTime.Now.AddDays(-1),
                LoyaltyPoints = 0,
                Cpf = "00000000000",
                Name = "Lucas"
            };

            var _clientService = new ClientService(_clientRepository.Object);

            _clientRepository.Setup(x => x.GetClientByCpf(client.Cpf)).Returns(client);

            //action
            //assert
            Assert.That(() => _clientService.DeleteClient(client.Cpf), Throws.Nothing);
        }

        [Test]
        public void When_AddClient_And_CpfAlreadyExist_Then_MustBeInvalid()
        {
            //arrange
            var _clientRepository = new Mock<IClientRepository>();

            var newClient = new Client()
            {
                Id = 1,
                BirthDate = System.DateTime.Now.AddDays(-1),
                LoyaltyPoints = 0,
                Cpf = "00000000000",
                Name = "Lucas"
            };

            var oldClient = new Client()
            {
                Id = 2,
                BirthDate = System.DateTime.Now.AddDays(-1),
                LoyaltyPoints = 0,
                Cpf = "00000000000",
                Name = "Goku"
            };

            var clientList = new List<Client>();
            clientList.Add(oldClient);
            _clientRepository.Setup(x => x.GetAllClients()).Returns(clientList);

            _clientRepository.Setup(x => x.AddClient(newClient));

            var _clientService = new ClientService(_clientRepository.Object);

            //action
            //assert
            Assert.That(() => _clientService.AddClient(newClient), Throws.Exception);
        }

    }
}
