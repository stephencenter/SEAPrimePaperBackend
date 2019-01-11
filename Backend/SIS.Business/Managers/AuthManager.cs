using AutoMapper;
using Microsoft.Extensions.Configuration;
using PrimePaper.Business.DataContract.Authorization;
using PrimePaper.Database.DataContract.Authorization;
using System.Threading.Tasks;

namespace PrimePaper.Business.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthManager(IMapper mapper, IAuthRepository authRepository, IConfiguration configuration)
        {
            _mapper = mapper;
            _authRepository = authRepository;
            _configuration = configuration;
        }

        public async Task<ReceivedExistingUserDTO> RegisterUser(RegisterUserDTO userDTO)
        {
            var rao = _mapper.Map<RegisterUserRAO>(userDTO);

            var returnedRAO = await _authRepository.Register(rao, userDTO.Password);

            if(returnedRAO != null)
            {
                return _mapper.Map<ReceivedExistingUserDTO>(returnedRAO);
            }

            return null;
        }

        public async Task<ReceivedExistingUserDTO> LoginUser(QueryForExistingUserDTO queryForUserDTO)
        {
            var queryForUserRAO = _mapper.Map<QueryForExistingUserRAO>(queryForUserDTO);

            var receivedUser = await _authRepository.Login(queryForUserRAO);

            var userDTO =  _mapper.Map<ReceivedExistingUserDTO>(receivedUser);

            return userDTO;
        }

        public async Task<bool> UserExists(string email)
        {
           return await _authRepository.UserExists(email);
        }
    }
}
