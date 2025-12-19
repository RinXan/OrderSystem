using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    public class OrderService
    {
        private readonly IProductRepository _repository;

        public OrderService(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void AddProductToOrder(Order order, string name)
        {
            if (order is null) throw new ArgumentException("Order is empty", nameof(name)); ;
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Product name is empty", nameof(name));

            Product product = _repository.GetByName(name);

            if (product is null) throw new InvalidOperationException("Product not found");

            order.AddProduct(product);
        }
    }
}
