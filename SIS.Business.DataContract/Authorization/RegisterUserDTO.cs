﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Business.DataContract.Authorization
{
    public class RegisterUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
