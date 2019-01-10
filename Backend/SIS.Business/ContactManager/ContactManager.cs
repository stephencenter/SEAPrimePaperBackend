using AutoMapper;
using RedStarter.Business.DataContract.Application.DTOs;
using RedStarter.Business.DataContract.Application.Interfaces;
using RedStarter.Business.DataContract.Contact;
using RedStarter.Database.DataContract.Application;
using RedStarter.Database.DataContract.Authorization.Interfaces;
using RedStarter.Database.DataContract.Roles.Interfaces;
using System;
using System.Threading.Tasks;

namespace RedStarter.Business.Managers.Application
{
    public class ContactManager : IContactManager
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IContactRepository _contactRepository;

        public ContactManager(IMapper mapper,IContactRepository contactRepository, IAuthRepository authRepository, IRoleRepository roleRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _authRepository = authRepository;
            _roleRepository = roleRepository;
        }

        public async Task<bool> ContactCreate(ContactCreateDTO DTO)
        {
            var user = await _authRepository.GetUserById(DTO.OwnerId);

            if (DTO.OwnerId != user.Id)
                throw new Exception("Unauthorized"); //TODO: Adjustments

            var rao = _mapper.Map<ContactCreateRAO>(DTO);

            rao.OwnerId = DTO.OwnerId;

            if (await _contactRepository.CreateContact(rao))
            {
                await _roleRepository.AddUserToRole(user, "user");
                return true;
            }
            else
            {
                return false;
            }
              
        }

        public async Task<bool> EditContact(ContactEditDTO dto)
        {
            var rao = _mapper.Map<ContactEditRAO>(dto);

            if (await _contactRepository.EditContact(rao))
            {
                return true;
            }

            return false;
        }
    }
}
