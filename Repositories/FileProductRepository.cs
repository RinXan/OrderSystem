using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    public class FileProductRepository : IProductRepository
    {
        private string FilePath { get; }

        public FileProductRepository(string filePath) 
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath), "File path is not correct");
            FilePath = filePath;
        }

        public List<Product> GetAll()
        {
            string[] file = File.ReadAllLines(FilePath);
            List<Product> products = new List<Product>();

            foreach (string line in file)
            {
                string[] temp = line.Split(';');
                string name = temp[0];
                decimal price = decimal.Parse(temp[1]);

                products.Add(new Product(name, price));
            }

            return products;
        }

        public Product GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            return GetAll().FirstOrDefault(p => p.Name == name);
        }
    }
}
