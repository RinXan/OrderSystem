namespace OrderSystem
{
    public class DeliveryOrder : Order
    {
        public decimal DeliveryPrice { get; }
        public DeliveryOrder(int id, decimal deliveryPrice) : base(id)
        {
            if (deliveryPrice <= 0) throw new ArgumentOutOfRangeException(nameof(deliveryPrice), "Delivery price should be greater than 0");
            DeliveryPrice = deliveryPrice;
        }
        public override void Process()
        {
            decimal productsTotal = CalculateProductsTotal();
            decimal finalPrice = productsTotal + DeliveryPrice;

            Console.WriteLine($"Order #{Id}");
            Console.WriteLine($"Products total: {productsTotal}");
            Console.WriteLine($"Delivery price: {DeliveryPrice}");
            Console.WriteLine($"Final total: {finalPrice}");
        }
        public override decimal CalculateTotal()
        {
            return base.CalculateTotal() + DeliveryPrice;
        }
    }
}
