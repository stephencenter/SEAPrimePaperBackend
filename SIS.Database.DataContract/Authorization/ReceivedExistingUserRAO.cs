﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Database.DataContract.Authorization
{
    public class ReceivedExistingUserRAO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
    }
}
