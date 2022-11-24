using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Orders;
using TunisBrandCo.Infra.Data.Features.Clients;

namespace TunisBrandCo.Infra.Data.Features.Orders
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly OrderDAO _orderDAO;

        public OrderRepository()
        {
            _orderDAO = new OrderDAO();
        }
        public void AddOrder(Order newOrder)
        {
            _orderDAO.AddOrder(newOrder);
        }

        public void DeleteOrder(int orderId)
        {
            _orderDAO.DeleteOrder(orderId);
        }

        public void GetStatus(Order Order)
        {
            _orderDAO.GetStatusById(Order.Id);
        }

        public void UpdateStatus(int status)
        {
            throw new NotImplementedException();
        }
    }
}
