using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TunisBrandCo.Application.Features.Products;
using TunisBrandCo.Domain.Features.Products;
using TunisBrandCo.Infra.Data.Features.Products;

namespace TunisBrandCo.Tests.Features.Products
{
    public class ProductTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Add Product
        [Test]
        public void When_AddProduct_And_AllDataIsOk_Then_MustBeValid()
        {
            //arrange
            var _productRepository = new Mock<IProductRepository>();

            var product = new Product()
            {
                Id = 1,
                Description = "Camisa",
                ExpiryDate = DateTime.Now.AddDays(-1),
                IsActive = true,
                Price = 10,
                StockQuantity = 10,
            };

            var productList = new List<Product>();

            _productRepository.Setup(x => x.GetAllProducts()).Returns(productList);

            _productRepository.Setup(x => x.AddProduct(product));

            var _productService = new ProductService(_productRepository.Object);

            //action
            //assert
            Assert.That(() => _productService.AddProduct(product), Throws.Nothing);
        }

        [Test]
        public void When_AddProduct_And_IdAlreadyExist_Then_MustBeInvalid()
        {
            //arrange
            var _productRepository = new Mock<IProductRepository>();

            var newProduct = new Product()
            {
                Id = 1,
                Description = "Camisa",
                ExpiryDate = DateTime.Now.AddDays(-1),
                IsActive = true,
                Price = 10,
                StockQuantity = 10,
            };

            var OldProduct = new Product()
            {
                Id = 1,
                Description = "Camisa",
                ExpiryDate = DateTime.Now.AddDays(-1),
                IsActive = true,
                Price = 10,
                StockQuantity = 10,
            };

            var productList = new List<Product>();
            productList.Add(OldProduct);
            _productRepository.Setup(x => x.GetAllProducts()).Returns(productList);

            _productRepository.Setup(x => x.AddProduct(newProduct));

            var _productService = new ProductService(_productRepository.Object);

            //action
            //assert
            Assert.That(() => _productService.AddProduct(newProduct), Throws.Exception);
        }

        [Test]
        public void When_ValidateProduct_And_DescriptionHaveLessThan3Characters_Then_MustBeInvalid()
        {
            //arrange
            var _productRepository = new Mock<IProductRepository>();

            var product = new Product()
            {
                Id = 1,
                Description = "Ca",
                ExpiryDate = DateTime.Now.AddDays(-1),
                IsActive = true,
                Price = 10,
                StockQuantity = 10,
            };

            var productList = new List<Product>();
            _productRepository.Setup(x => x.GetAllProducts()).Returns(productList);

            _productRepository.Setup(x => x.AddProduct(product));

            var _productService = new ProductService(_productRepository.Object);

            //action
            //assert
            Assert.That(() => _productService.AddProduct(product), Throws.Exception);
        }

        [Test]
        public void When_ValidateProduct_And_PriceIs0_Then_MustBeInvalid()
        {
            //arrange
            var _productRepository = new Mock<IProductRepository>();

            var product = new Product()
            {
                Id = 1,
                Description = "Camisa",
                ExpiryDate = DateTime.Now.AddDays(-1),
                IsActive = true,
                Price = 0,
                StockQuantity = 10,
            };

            var productList = new List<Product>();
            _productRepository.Setup(x => x.GetAllProducts()).Returns(productList);

            _productRepository.Setup(x => x.AddProduct(product));

            var _productService = new ProductService(_productRepository.Object);

            //action
            //assert
            Assert.That(() => _productService.AddProduct(product), Throws.Exception);
        }

        [Test]
        public void When_GetAllProducts_MustWorks()
        {
            //arrange
            var _productRepository = new ProductRepository();

            //action
            //assert
            Assert.That(() => _productRepository.GetAllProducts(), Throws.Nothing);
        }

        //AddStock
        [Test]
        public void When_AddSotck_And_AllDataIsOk_Then_MustBeValid()
        {
            //arrange
            var _productRepository = new Mock<IProductRepository>();

            var quantity = 1;

            var product = new Product()
            {
                Id = 1,
                Description = "Camisa",
                ExpiryDate = DateTime.Now.AddDays(-1),
                IsActive = true,
                Price = 10,
                StockQuantity = 10,
            };

            var productList = new List<Product>();

            _productRepository.Setup(x => x.GetProductById(product.Id)).Returns(product);

            _productRepository.Setup(x => x.StockManagement(product, quantity));

            var _productService = new ProductService(_productRepository.Object);

            //action
            //assert
            Assert.That(() => _productService.AddStock(product.Id, quantity), Throws.Nothing);
        }

        [Test]
        public void When_AddSotck_And_QuantityIsLessThan1_Then_MustBeValid()
        {
            //arrange
            var _productRepository = new Mock<IProductRepository>();

            var quantity = 0;

            var product = new Product()
            {
                Id = 1,
                Description = "Camisa",
                ExpiryDate = DateTime.Now.AddDays(-1),
                IsActive = true,
                Price = 10,
                StockQuantity = 10,
            };

            var productList = new List<Product>();

            _productRepository.Setup(x => x.GetProductById(product.Id)).Returns(product);

            _productRepository.Setup(x => x.StockManagement(product, quantity));

            var _productService = new ProductService(_productRepository.Object);

            //action
            //assert
            Assert.That(() => _productService.AddStock(product.Id, quantity), Throws.Exception);
        }

        //RemoveStock
        [Test]
        public void When_RemoveSotck_And_AllDataIsOk_Then_MustBeValid()
        {
            //arrange
            var _productRepository = new Mock<IProductRepository>();

            var quantity = 1;

            var product = new Product()
            {
                Id = 1,
                Description = "Camisa",
                ExpiryDate = DateTime.Now.AddDays(-1),
                IsActive = true,
                Price = 10,
                StockQuantity = 10,
            };

            var productList = new List<Product>();

            _productRepository.Setup(x => x.GetProductById(product.Id)).Returns(product);

            _productRepository.Setup(x => x.StockManagement(product, quantity));

            var _productService = new ProductService(_productRepository.Object);

            //action
            //assert
            Assert.That(() => _productService.RemoveStock(product.Id, quantity), Throws.Nothing);
        }

        [Test]
        public void When_RemoveSotck_And_QuantityIsLessThan1_Then_MustBeValid()
        {
            //arrange
            var _productRepository = new Mock<IProductRepository>();

            var quantity = 0;

            var product = new Product()
            {
                Id = 1,
                Description = "Camisa",
                ExpiryDate = DateTime.Now.AddDays(-1),
                IsActive = true,
                Price = 10,
                StockQuantity = 10,
            };

            var productList = new List<Product>();

            _productRepository.Setup(x => x.GetProductById(product.Id)).Returns(product);

            _productRepository.Setup(x => x.StockManagement(product, quantity));

            var _productService = new ProductService(_productRepository.Object);

            //action
            //assert
            Assert.That(() => _productService.RemoveStock(product.Id, quantity), Throws.Exception);
        }


    }
}

