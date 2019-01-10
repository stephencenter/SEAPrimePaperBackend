using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Database.DataContract.Application
{
  public class ContactEditRAO
    {
        public int ContactEntityId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
