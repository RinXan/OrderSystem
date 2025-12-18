namespace OrderSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var product = new Product("Laptop", 1000);
                var product2 = new Product("Laptop2", 5000);

                Order order = new PickupOrder(1);
                Order order2 = new DeliveryOrder(2, 99);

                order.AddProduct(product);
                order2.AddProduct(product);
                order2.AddProduct(product2);

                order.Process();
                order2.Process();

                order.SetPaymentMethod(new CashPayment());
                order2.SetPaymentMethod(new CardPayment());

                order.Pay();
                order2.Pay();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}