namespace PrimePaper.API.DataContract.Cart
{
    public class CartCreateRequest
    {
        public int ProductEntityId { get; set; }
        public int OwnerId { get; set; }
        public int Quantity { get; set; }
    }
}
