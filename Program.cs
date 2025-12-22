using OrderSystem.Logging;

namespace OrderSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "D:\\practise\\c#\\OrderSystem\\Infrastructure\\products.txt";
                
                IProductRepository productRepository = new FileProductRepository(filePath);
                ILogger logger = new ConsoleLogger();

                OrderService orderService = new OrderService(productRepository, logger);

                Order order = new DeliveryOrder(1, 12);

                orderService.AddProductToOrder(order, "Asus ROG");
                orderService.AddProductToOrder(order, "Acer Aspire 7");

                order.SetPaymentMethod(new CardPayment());

                bool paymentResult = order.Pay();

                if (!paymentResult)
                {
                    Console.WriteLine("Payment failed");
                    return;
                }
                
                order.Process();

                Console.WriteLine("Order completed successfully");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}