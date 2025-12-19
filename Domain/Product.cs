using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }

        public Product(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name cannot be null or empty", nameof(name));
            if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price), "price must be greater than 0");
            
            Name = name;
            Price = price;
        }

        public override string ToString() 
        {
            return $"Name: {Name}\tPrice: {Price}";
        }
    }
}
