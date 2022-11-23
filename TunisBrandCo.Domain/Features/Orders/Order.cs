using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Products;
using TunisBrandCo.Domain.Features.Clients;


namespace TunisBrandCo.Domain.Features.Orders
{
    public class Order
    {
        public int Id { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public Order(int id, int productId, int clientId, int productQuantity, decimal totalPrice, DateTime orderDate, string status)
        {
            Id = id;
            ClientId = clientId;
            ProductQuantity = productQuantity;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            Status = status;
            ProductId = productId;
        }

        public Order(int id, int productId, int productQuantity, decimal totalPrice, DateTime orderDate, string status)
        {
            Id = id;
            ProductId = productId;
            ProductQuantity = productQuantity;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            Status = status;
        }
    }
}
