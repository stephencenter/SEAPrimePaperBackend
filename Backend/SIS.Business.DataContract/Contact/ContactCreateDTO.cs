using System;

namespace RedStarter.Business.DataContract.Contact.DTOs
{
    public class ContactCreateDTO
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public int OwnerId { get; set; }
    }
}

