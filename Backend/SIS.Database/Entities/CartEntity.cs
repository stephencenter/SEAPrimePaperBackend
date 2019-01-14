using System.ComponentModel.DataAnnotations;

namespace PrimePaper.Database.Entities
{
    public class CartEntity
    {
        [Key] // The Key, unique identifier for this specific CartEntity
        public int CartEntityId { get; set; }

        [Required] // The ID of the ProductEntity that this CartEntity corresponds to
        public int ProductEntityId { get; set; }

        [Required] // The ID of the User that put this CartEntity in the cart.
        public int OwnerId { get; set; }

        [Required] // The amount of the product you want to purchase
        public int Quantity { get; set; }
    }
}
