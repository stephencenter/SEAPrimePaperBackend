using PrimePaper.Database.DataContract.Authorization;
using System.Threading.Tasks;

namespace PrimePaper.Database.DataContract.Roles
{
    public interface IRoleRepository
    {
        Task<bool> AddUserToRole(ReceivedExistingUserRAO User, string Role);
    }
}