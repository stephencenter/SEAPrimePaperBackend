using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Database.DataContract.Cart
{
    public class CartCreateRAO
    {
        public int ProductEntityId { get; set; }
        public int OwnerId { get; set; }
        public int Quantity { get; set; }
    }
}
