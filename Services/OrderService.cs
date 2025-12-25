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
            if (order is null) throw new ArgumentNullException(nameof(order), "Order is empty");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Product name is empty", nameof(name));

            _logger.Log(LogLevel.Info, $"Trying to add product '{name}'");

            Product product = _repository.GetByName(name);

            if (product is null)
            {
                _logger.Log(LogLevel.Error, $"Product '{name}' not found");
                throw new InvalidOperationException("Product not found");
            }

            order.AddProduct(product);

            _logger.Log(LogLevel.Info, $"Product '{name}' added to order #{order.Id}");
        }
    }
}
