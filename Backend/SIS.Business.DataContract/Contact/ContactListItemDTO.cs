﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Business.DataContract.Contact
{
   public class ContactListItemDTO
    {
        public int ContactEntityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
