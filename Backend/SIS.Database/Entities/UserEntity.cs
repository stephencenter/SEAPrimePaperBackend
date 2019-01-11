using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PrimePaper.Database.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        public ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
