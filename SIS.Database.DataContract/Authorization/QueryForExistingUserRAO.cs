﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Database.DataContract.Authorization
{
    public class QueryForExistingUserRAO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
