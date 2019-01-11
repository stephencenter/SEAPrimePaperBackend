using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RedStarter.Database.Entities.Product
{
    public class ProductEntity
    {
        [Key]
        public int ProductEntityId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int OwnerId { get; set; }


        [Required]
        public DateTimeOffset DateCreated { get; set; }
    }
}
