using PrimePaper.Database.DataContract.Authorization.RAOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Database.DataContract.User
{
    public interface IUserRepository
    {
        Task<ReceivedExistingUserRAO> GetUser(int userId);
    }
}
