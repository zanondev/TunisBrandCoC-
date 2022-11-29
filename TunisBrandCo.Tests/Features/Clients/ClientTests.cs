using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Clients;
using TunisBrandCo.Application.Features.Client;
using TunisBrandCo.Infra.Data.Features.Clients;

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
            var client = new Client();
            client.Id = 1;
            client.BirthDate = System.DateTime.Now.AddDays(-1);
            client.LoyaltyPoints = 0;
            client.Cpf = "111111111";

            //action
            var isValid = client.Validate();

            //assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void When_ValidateClient_And_BirthDateIsLessThanCurrentDate_Then_MustBeInvalid()
        {
            //arrange
            var client = new Client();
            client.Id = 1;
            client.BirthDate = System.DateTime.Now.AddDays(1);
            client.LoyaltyPoints = 0;
            client.Cpf = "111111111";
            client.Name = "Lucas";

            //action
            var isValid = client.Validate();

            //assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void When_ValidateClient_And_CpfHaveMoreThan11Characters_Then_MustBeInvalid()
        {
            //arrange
            var client = new Client();
            client.Id = 1;
            client.BirthDate = System.DateTime.Now.AddDays(-1);
            client.LoyaltyPoints = 0;
            client.Cpf = "111111111111";
            client.Name = "Lucas";

            //action
            var isValid = client.Validate();

            //assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void When_PostClient_And_AllDataIsOk_Then_MustBeValid()
        {
            //arrange
            var _clientRepository = new ClientRepository();
            var _clientService = new ClientService(_clientRepository);
            var client = new Client();
            client.Id = 1;
            client.BirthDate = System.DateTime.Now.AddDays(-1);
            client.LoyaltyPoints = 0;
            client.Cpf = "coco";
            client.Name = "Lucas";

            //action
            //assert
            Assert.That(() => _clientService.AddClient(client), Throws.Nothing);
        }

        [Test]
        public void When_GetAllClients__MustWorks()
        {
            //arrange
            var _clientRepository = new ClientRepository();
            var _clientService = new ClientService(_clientRepository);
            var client = new Client();
            client.Id = 1;
            client.BirthDate = System.DateTime.Now.AddDays(-1);
            client.LoyaltyPoints = 0;
            client.Cpf = "111111111";
            client.Name = "Lucas";

            //action
            //assert
            Assert.That(() => _clientRepository.GetAllClients(), Throws.Nothing);
        }



    }
}
