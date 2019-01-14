using PrimePaper.Database.DataContract.Authorization;
using System.Threading.Tasks;

namespace PrimePaper.Database.DataContract.User
{
    public interface IUserRepository
    {
        Task<ReceivedExistingUserRAO> GetUser(int userId);
    }
}
