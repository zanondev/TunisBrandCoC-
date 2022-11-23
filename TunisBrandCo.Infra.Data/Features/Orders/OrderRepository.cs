using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Orders;

namespace TunisBrandCo.Infra.Data.Features.Orders
{
    internal class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int OrderId)
        {
            throw new NotImplementedException();
        }

        public void GetStatus(Order Order)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int status)
        {
            throw new NotImplementedException();
        }
    }
}
