using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Database.Entities
{
    public class RoleEntity : IdentityRole<int>
    {
        public ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
