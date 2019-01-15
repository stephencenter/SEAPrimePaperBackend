namespace PrimePaper.Business.DataContract.Cart
{
    public class CartGetDTO
    {
        public int CartEntityId { get; set; }
        public int ProductEntityId { get; set; }
        public int Quantity { get; set; }
    }
}
