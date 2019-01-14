using System.Threading.Tasks;

namespace PrimePaper.Database.DataContract.Authorization
{
    public interface IAuthRepository
    {
        Task<ReceivedExistingUserRAO> Register(RegisterUserRAO regUserRAO, string password);
        Task<ReceivedExistingUserRAO> Login(QueryForExistingUserRAO queryRao);
        Task<bool> UserExists(string username);
        Task<ReceivedExistingUserRAO> GetUserById(int ownerId);
    }
}
