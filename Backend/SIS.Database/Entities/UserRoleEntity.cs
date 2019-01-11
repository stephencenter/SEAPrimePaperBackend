using Microsoft.AspNetCore.Identity;
using PrimePaper.Database.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Database.Entities.Roles
{
    public class UserRoleEntity : IdentityUserRole<int>
    {
        public UserEntity User { get; set; }
        public RoleEntity Role { get; set; }
    }
}
