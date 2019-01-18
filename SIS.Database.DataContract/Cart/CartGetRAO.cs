namespace PrimePaper.Database.DataContract.Cart
{
    public class CartGetRAO
    {
        public int CartEntityId { get; set; }
        public int ProductEntityId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Subtotal { get; set; }
    }
}