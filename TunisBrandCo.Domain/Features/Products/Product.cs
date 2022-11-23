using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Orders;

namespace TunisBrandCo.Domain.Features.Products
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public Order Order { get; set; }

        public Product(int id, decimal price, DateTime expiryDate, int stockQuantity, bool isActive, string description)
        {
            Id = id;
            Price = price;
            ExpiryDate = expiryDate;
            StockQuantity = stockQuantity;
            IsActive = isActive;
            Description = description;

            isActive = true;
        }
    }
}
