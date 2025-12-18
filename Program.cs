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
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}