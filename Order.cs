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

        public decimal CalculateTotal()
        {
            decimal total = 0;

            foreach (Product product in Products)
            {
                total += product.Price;
            }

            return total;
        }

        public abstract void Process();
    }
}
