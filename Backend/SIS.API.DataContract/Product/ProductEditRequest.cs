using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.API.DataContract.Product
{
   public  class ProductEditRequest
    {
        public int ProductEntityId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
