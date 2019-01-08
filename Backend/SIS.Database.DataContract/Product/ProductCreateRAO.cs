using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Database.DataContract.Product
{
    public class ProductCreateRAO
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int OwnerId { get; set; }

    }
}
