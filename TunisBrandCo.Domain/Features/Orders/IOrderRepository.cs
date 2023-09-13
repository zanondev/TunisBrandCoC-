using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Clients;
using TunisBrandCo.Domain.Features.Products;

namespace TunisBrandCo.Domain.Features.Orders
{
    public interface IOrderRepository
    {
        void AddOrder(Order newOrder);
        void DeleteOrder(int OrderId);
        List<Order> GetAllOrders();
        Order GetStatus(int Id);
        void UpdateStatus(int orderId, int status);
        Order GetOrderById(int orderId);
    }
}
