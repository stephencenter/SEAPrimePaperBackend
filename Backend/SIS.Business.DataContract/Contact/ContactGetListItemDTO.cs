using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Business.DataContract.Contact
{
    public class ContactGetListItemDTO
    {
        public int ContactEntityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
