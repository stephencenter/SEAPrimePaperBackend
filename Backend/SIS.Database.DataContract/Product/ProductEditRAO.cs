using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Database.DataContract.Product
{
   public class ProductEditRAO
    {
        public int ProductEntityId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
