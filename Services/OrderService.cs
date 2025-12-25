using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSystem.Logging;

namespace OrderSystem
{
    public class OrderService
    {
        private readonly IProductRepository _repository;
        private readonly ILogger _logger;

        public OrderService(IProductRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddProductToOrder(Order order, string name)
        {
            if (order is null) throw new ArgumentNullException("Order is empty", nameof(order)); ;
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Product name is empty", nameof(name));

            _logger.Log($"Trying to add product '{name}'");

            Product product = _repository.GetByName(name);

            if (product is null)
            {
                _logger.Error($"Product '{name}' not found");
                throw new InvalidOperationException("Product not found");
            }

            order.AddProduct(product);

            _logger.Log($"Product '{name}' added to order #{order.Id}");
        }
    }
}
