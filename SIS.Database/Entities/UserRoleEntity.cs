using Microsoft.AspNetCore.Identity;

namespace PrimePaper.Database.Entities
{
    public class UserRoleEntity : IdentityUserRole<int>
    {
        public UserEntity User { get; set; }
        public RoleEntity Role { get; set; }
    }
}
