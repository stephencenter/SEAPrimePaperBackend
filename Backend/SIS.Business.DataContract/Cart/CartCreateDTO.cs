using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Business.DataContract.Cart
{
    public class CartCreateDTO
    {
        public int ProductEntityId { get; set; }
        public Guid OwnerId { get; set; }
        public int Quantity { get; set; }
    }
}
