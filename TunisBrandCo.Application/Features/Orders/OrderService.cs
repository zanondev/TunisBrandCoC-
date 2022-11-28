using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Exceptions;
using TunisBrandCo.Domain.Features.Orders;

namespace TunisBrandCo.Application.Features.Order
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //public object AddOrder(Domain.Features.Orders.Order newOrder)
        //{
        //    if (newOrder == null)
        //        throw new NotFoundException($"Product Id: {newOrder.Id} doesn't exists.");

        //    var orderList = _orderRepository.GetAllProducts();

        //    foreach (var product in orderList)
        //    {
        //        if (product.Id == newOrder.Id)
        //            throw new AlreadyExistsException($"Product Id: {newProduct.Id} already exists.");
        //    }

        //    _productRepository.AddProduct(newProduct);

        //    return newProduct;
        //}
    }
}
