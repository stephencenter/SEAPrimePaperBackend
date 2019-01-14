using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Business.DataContract.Product
{
    public class ProductCreateDTO
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
