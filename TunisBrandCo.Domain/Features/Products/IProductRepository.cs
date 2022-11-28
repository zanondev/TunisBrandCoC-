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
        void UpdateStatus(Product product, bool isActive);
        void StockManagement(Product product, int quantity);
        List<Product> GetAllProducts();
        Product GetProductById(int productId);


    }
}
