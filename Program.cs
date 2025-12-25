using OrderSystem.Logging;

namespace OrderSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string repoPath = "D:\\practise\\c#\\OrderSystem\\Infrastructure\\products.txt";
                string filePath = "D:\\practise\\c#\\OrderSystem\\Infrastructure\\log.txt";
                
                IProductRepository productRepository = new FileProductRepository(repoPath);
                ILogger logger = new FileLogger(filePath);

                OrderService orderService = new OrderService(productRepository, logger);

                Order order = new DeliveryOrder(1, 12);

                orderService.AddProductToOrder(order, "Asus ROG");

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