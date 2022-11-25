using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Products;

namespace TunisBrandCo.Application.Features.Order
{
    public class OrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;

        public OrderService(IProductRepository productRepository, ILogger logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

    }
}
