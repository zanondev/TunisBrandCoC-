using Microsoft.AspNetCore.Mvc;
using TunisBrandCo.Application.Features.Order;
using TunisBrandCo.Application.Features.Products;
using TunisBrandCo.Domain.Features.Clients;
using TunisBrandCo.Domain.Features.Orders;
using TunisBrandCo.Domain.Features.Products;
using TunisBrandCo.Infra.Data.Features.Orders;
using TunisBrandCo.Infra.Data.Features.Products;

namespace TunisBrandCo.API.Controllers.Features.Orders
{
    [ApiController]
    [Route("api/orders")]

    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ProductService _productService;
        private readonly OrderService _orderService;
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;

        public OrderController()
        {
            _orderRepository = new OrderRepository();
            _orderService = new OrderService(_orderRepository, _productService, _clientRepository, _productRepository);
        }

        [HttpPost]
        public IActionResult PostOrder([FromBody] Order newOrder)
        {
            return Ok(_orderService.AddOrder(newOrder));
        }
    }
}
