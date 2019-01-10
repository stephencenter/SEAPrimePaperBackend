using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RedStarter.Database.Entities.Application
{
    public class ContactEntity
    {
        [Key]
        public int ContactEntityId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

       

        [Required]
        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
}
