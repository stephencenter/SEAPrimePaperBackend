using System.ComponentModel.DataAnnotations;

namespace RedStarter.API.DataContract.Contact
{
    public class ContactCreateRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}

