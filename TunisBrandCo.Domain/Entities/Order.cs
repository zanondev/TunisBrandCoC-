using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunisBrandCo.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Client Client { get; set; }
        public int ProductQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public Enum Status { get; set; }

        public Order(int id, Product product, Client client, int productQuantity, decimal totalPrice, DateTime orderDate, Enum status)
        {
            Id = id;
            Product = product;
            Client = client;
            ProductQuantity = productQuantity;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            Status = status;
        }

        public Order(int id, Product product, int productQuantity, decimal totalPrice, DateTime orderDate, Enum status)
        {
            Id = id;
            Product = product;
            ProductQuantity = productQuantity;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            Status = status;
        }
    }
}
