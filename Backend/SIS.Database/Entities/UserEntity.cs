using Microsoft.AspNetCore.Identity;
using PrimePaper.Database.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Database.Entities.People
{
    public class UserEntity : IdentityUser<int>
    {
        public ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
