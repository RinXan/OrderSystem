namespace OrderSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "D:\\practise\\c#\\OrderSystem\\products.txt";
                
                IProductRepository productRepository = new FileProductRepository(filePath);

                OrderService orderService = new OrderService(productRepository);

                Order order = new DeliveryOrder(1, 12);
                Order order2 = new DeliveryOrder(2, 38);

                orderService.AddProductToOrder(order, "Asus ROG");
                orderService.AddProductToOrder(order, "Acer Aspire 7");

                orderService.AddProductToOrder(order2, "Acer Aspire 7");
                orderService.AddProductToOrder(order2, "Acer Nitro 5");

                order.SetPaymentMethod(new CardPayment());
                order2.SetPaymentMethod(new CardPayment());

                bool paymentResult = order.Pay();
                bool paymentResult2 = order2.Pay();

                if (!paymentResult && !paymentResult2)
                {
                    Console.WriteLine("Payment failed");
                    return;
                }
                
                order.Process();
                order2.Process();

                Console.WriteLine("Order completed successfully");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}