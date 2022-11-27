using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Products;

namespace TunisBrandCo.Infra.Data.Features.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _productDAO;

        public ProductRepository()
        {
            _productDAO = new ProductDAO();
        }

        public void AddProduct(Product newProduct)
        {
            _productDAO.AddProduct(newProduct);
        }

        public void AddStock(Product product, int quantity)
        {
            _productDAO.AddStock(product, quantity);
            //duvida
        }

        public List<Product> GetAllProducts()
        {
            return _productDAO.GetAllProducts();
        }

        public Product GetProductById(int productId)
        {
            return _productDAO.GetProductById(productId);
        }

        public void UpdateProduct(Product editedProduct)
        {
            _productDAO.UpdateProduct(editedProduct);
        }

        public void UpdateStatus(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
