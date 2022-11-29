using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TunisBrandCo.Application.Features.Client;
using TunisBrandCo.Application.Features.Order;
using TunisBrandCo.Application.Features.Products;
using TunisBrandCo.Domain.Features.Clients;
using TunisBrandCo.Domain.Features.Orders;
using TunisBrandCo.Domain.Features.Products;
using TunisBrandCo.Infra.Data.Features.Orders;


namespace TunisBrandCo.Tests.Features.Orders
{
    public class OrderTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void When_AddOrder_And_AllDataIsOk_Then_MustBeValid()
        {
            //arrange
            var _orderRepository = new Mock<IOrderRepository>();
            var _productRepository = new Mock<IProductRepository>();
            var _clientRepository = new Mock<IClientRepository>();

            var client = new Client()
            {
                Id = 1,
                BirthDate = System.DateTime.Now.AddDays(-1),
                LoyaltyPoints = 0,
                Cpf = "00000000000",
                Name = "Lucas"
            };

            var product = new Product()
            {
                Id = 1,
                Description = "Camisa",
                ExpiryDate = DateTime.Now.AddDays(-1),
                IsActive = true,
                Price = 10,
                StockQuantity = 10,
            };

            var order = new Order()
            {
                Id = 1,
                Client = client,
                Product = product,
                OrderDate = DateTime.Now,
                ProductQuantity = 1,
                Status = 1,
                TotalPrice = 10
            };

            var orderList = new List<Order>();
            _orderRepository.Setup(x => x.GetAllOrders()).Returns(orderList);

            _productRepository.Setup(x => x.GetProductById(client.Id)).Returns(product);
            _clientRepository.Setup(x => x.GetClientById(client.Id)).Returns(client);

            var _productService = new ProductService(_productRepository.Object);

            _orderRepository.Setup(x => x.AddOrder(order));

            var _orderService = new OrderService(_productRepository.Object, _clientRepository.Object, _productService, _orderRepository.Object);

            //action
            //assert
            Assert.That(() => _orderService.AddOrder(order), Throws.Nothing);
        }


    }
}
