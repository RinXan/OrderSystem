using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetByName(string name);
    }
}
