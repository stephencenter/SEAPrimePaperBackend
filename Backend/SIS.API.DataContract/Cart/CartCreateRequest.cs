using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.API.DataContract.Cart
{
    public class CartCreateRequest
    {
        public int ProductEntityId { get; set; }
        public Guid OwnerId { get; set; }
        public int Quantity { get; set; }
    }
}
