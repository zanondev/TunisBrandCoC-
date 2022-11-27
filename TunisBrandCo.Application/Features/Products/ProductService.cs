using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Products;
using TunisBrandCo.Infra.Data.Features.Products;
using TunisBrandCo.Domain.Exceptions;

namespace TunisBrandCo.Application.Features.Products
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = new ProductRepository();
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

            _productRepository.AddProduct(newProduct);

            return newProduct;
        }

        public string DeleteProduct(string cpf)
        {
            //var client = _clientRepository.GetClientByCpf(cpf);

            //if (client.Cpf == null)
            //    throw new NotFoundException($"Client: {client.Cpf} doesn't exists.");

            //_clientRepository.DeleteClient(client.Id);

            return "Produto deletado com sucesso!";
        }






    }
}
