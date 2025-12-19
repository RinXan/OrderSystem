using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    public class CashPayment : IPaymentMethod
    {
        public bool Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} by cash");
            return true;
        }
    }
}
