using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Database.DataContract.Application
{
    public class ContactGetListItemRAO
    {
        public int ContactEntityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
