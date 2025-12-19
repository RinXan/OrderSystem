using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    public class PickupOrder(int id) : Order(id)
    {
        public override void Process()
        {
            decimal productsTotal = CalculateTotal();

            Console.WriteLine($"Order #{Id}");
            Console.WriteLine($"Products total: {productsTotal}");
            Console.WriteLine($"Pickup: (no delivery)");
            Console.WriteLine($"Final total: {productsTotal}");
        }
    }
}
