using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrimePaper.Database.DataContract.Authorization;
using PrimePaper.Database.DataContract.Roles;
using PrimePaper.Database.Entities;
using System.Threading.Tasks;

namespace PrimePaper.Database.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UserManager<UserEntity> _userManager;

        public RoleRepository(UserManager<UserEntity> userManager, IMapper mapper)
        {
            _userManager = userManager;
        }

        public async Task<bool> AddUserToRole(ReceivedExistingUserRAO User, string Role)
        {
            var user = await _userManager.Users
                  .FirstOrDefaultAsync(u => u.Id == User.Id);

            await _userManager.AddToRoleAsync(user, Role);
            return true;
        }
    }
}
