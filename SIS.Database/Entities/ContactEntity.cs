using System;
using System.ComponentModel.DataAnnotations;

namespace PrimePaper.Database.Entities
{
    public class ContactEntity
    {
        [Key]
        public int ContactEntityId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public int OwnerId { get; set; } 


        [Required]
        public DateTimeOffset DateCreated { get; set; }
    }
}
