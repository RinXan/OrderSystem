using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    public abstract class Order
    {
        public int Id { get; }
        protected List<Product> Products;

        protected IPaymentMethod PaymentMethod;

        protected Order(int id)
        {
            if (id < 1) throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0");
            Id = id;
            Products = new List<Product>();
        }

        public void AddProduct(Product product) 
        {
            if (product is null) throw new ArgumentNullException(nameof(product), "Please add correct product");
            Products.Add(product);
        }

        public decimal CalculateTotal(decimal deliveryPrice = 0)
        {
            decimal total = deliveryPrice;

            foreach (Product product in Products)
            {
                total += product.Price;
            }

            return total;
        }

        public void SetPaymentMethod(IPaymentMethod method)
        {
            if (method is null) throw new ArgumentNullException(nameof(method), "Payment method hasn't set");
            PaymentMethod = method;
        }

        public bool Pay(decimal deliveryPrice = 0)
        {
            if (PaymentMethod is null) throw new InvalidOperationException("Payment method is not set");

            return PaymentMethod.Pay(CalculateTotal(deliveryPrice)); ;
        }

        public abstract void Process();
    }
}
