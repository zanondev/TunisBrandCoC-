using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Clients;

namespace TunisBrandCo.Domain.Features.Products
{
    public interface IProductRepository
    {
        void AddProduct(Product newProduct);
        void UpdateProduct(Product editedProduct);
        void UpdateStatus(int productId);
        void AddStock(Product product, int quantity);
    }
}
