using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    public class InMemoryProductRepository : IProductRepository
    {
        private List<Product> Products { get; }
        public InMemoryProductRepository(List<Product> products)
        {
            Products = products ?? throw new ArgumentNullException(nameof(products));
        }
    
        public List<Product> GetAll()
        {
            return new List<Product>(Products);
        }

        public Product GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            return Products.FirstOrDefault(p => p.Name == name);
        }
    }
}
