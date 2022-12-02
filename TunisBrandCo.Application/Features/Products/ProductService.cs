using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Products;
using TunisBrandCo.Infra.Data.Features.Products;
using TunisBrandCo.Domain.Exceptions;
using System.Net;

namespace TunisBrandCo.Application.Features.Products
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public Domain.Features.Products.Product AddProduct(Domain.Features.Products.Product newProduct)
        {
            if (newProduct == null)
                throw new NotFoundException($"Product Id: {newProduct.Id} doesn't exists.");

            var productList = _productRepository.GetAllProducts();

            foreach (var product in productList)
            {
                if (product.Id == newProduct.Id)
                    throw new AlreadyExistsException($"Product Id: {newProduct.Id} already exists.");
            }

            if (newProduct.Description.Length < 3)
                throw new NotAllowedException($"Invalid Description. Must have at least 3 characters.");

            if (newProduct.Price <= 0)
                throw new NotAllowedException($"Invalid Price. Must be more than 0.");

          

            _productRepository.AddProduct(newProduct);

            return newProduct;
        }

        public object AddStock(int productId, int quantity)
        {
            if(quantity < 1)
                throw new NotAllowedException($"Quantity: {quantity} can't be less than 1.");

            var product = _productRepository.GetProductById(productId);

            if (product.Id != productId)
                throw new NotFoundException($"Product: {product.Id} doesn't exists.");

            if (quantity > product.StockQuantity)
                throw new NotAllowedException($"Product quantity must be less or equal than stock.");

            var lastQuantity = product.StockQuantity;

            var newQuantity = lastQuantity + quantity;

            _productRepository.StockManagement(product, newQuantity);

            return "Quantidade em estoque alterada com sucesso!";
        }


        public object RemoveStock(int productId, int quantity)
        {
            if (quantity < 1)
                throw new NotAllowedException($"Quantity: {quantity} can't be less than 1.");

            var product = _productRepository.GetProductById(productId);

            if (product.Id != productId)
                throw new NotFoundException($"Product: {product.Id} doesn't exists.");

            var lastQuantity = product.StockQuantity;

            var newQuantity = lastQuantity - quantity;

            _productRepository.StockManagement(product, newQuantity);

            return "Quantidade em estoque alterada com sucesso!";
        }




        public object UpdateProduct(Product editedProduct)
        {
            var product = _productRepository.GetProductById(editedProduct.Id);

            if ((product.Id != editedProduct.Id) || editedProduct == null)
                throw new NotFoundException($"Product: {product.Id} doesn't exists.");

            product.Id = editedProduct.Id;
            product.ExpiryDate = editedProduct.ExpiryDate;
            product.Description = editedProduct.Description;
            product.Price = editedProduct.Price;
            product.IsActive = editedProduct.IsActive;
            product.StockQuantity = editedProduct.StockQuantity;


            _productRepository.UpdateProduct(product);

            return "Produto alterado com sucesso!";
        }

        public object UpdateStatus(Product editedProduct)
        {
            var product = _productRepository.GetProductById(editedProduct.Id);

            if ((product.Id != editedProduct.Id) || editedProduct == null)
                throw new NotFoundException($"Product: {product.Id} doesn't exists.");

            bool newStatus = !product.IsActive;

            _productRepository.UpdateStatus(product, newStatus);

            return "Status do produto alterado com sucesso!";
        }
    }
}
