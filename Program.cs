namespace OrderSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var product = new Product("Laptop", 1250);
                var product2 = new Product("Laptop2", 5000);

                PickupOrder pickupOrder = new PickupOrder(121);
                CashPayment cashPayment = new CashPayment();

                pickupOrder.AddProduct(product);
                pickupOrder.AddProduct(product2);
                pickupOrder.Process();
                pickupOrder.SetPaymentMethod(cashPayment);
                pickupOrder.Pay();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}