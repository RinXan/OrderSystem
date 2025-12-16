namespace OrderSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var product = new Product("Laptop", 1250);
                Console.WriteLine(product);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}