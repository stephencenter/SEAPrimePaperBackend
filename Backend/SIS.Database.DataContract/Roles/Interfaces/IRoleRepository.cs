using System.Threading.Tasks;
using PrimePaper.Database.DataContract.Authorization.RAOs;

namespace PrimePaper.Database.DataContract.Roles.Interfaces
{
    public interface IRoleRepository
    {
        Task<bool> AddUserToRole(ReceivedExistingUserRAO User, string Role);
    }
}