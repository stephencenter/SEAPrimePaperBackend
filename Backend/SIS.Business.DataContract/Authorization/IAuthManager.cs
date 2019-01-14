using System.Threading.Tasks;

namespace PrimePaper.Business.DataContract.Authorization
{
    public interface IAuthManager
    {
        Task<ReceivedExistingUserDTO> RegisterUser(RegisterUserDTO userDTO);
        Task<ReceivedExistingUserDTO> LoginUser(QueryForExistingUserDTO userDTO);
        Task<bool> UserExists(string user);
    }
}
