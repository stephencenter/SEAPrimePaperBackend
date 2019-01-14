using System;
using System.ComponentModel.DataAnnotations;

namespace PrimePaper.Database.Entities
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
