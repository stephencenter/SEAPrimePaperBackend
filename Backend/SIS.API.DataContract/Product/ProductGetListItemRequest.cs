using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.API.DataContract.Product
{
   public class ProductGetListItemRequest
    {
        public int ProductEntityId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
