using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Products;

namespace TunisBrandCo.Infra.Data.Features.Products
{
    internal class ProductRepository : IProductRepository
    {
        public void AddProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public void AddStock(Product product, int quantity)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product editedProduct)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
