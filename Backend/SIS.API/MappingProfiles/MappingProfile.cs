using AutoMapper;
using PrimePaper.API.DataContract.Authorization;
using PrimePaper.Business.DataContract.Authorization.DTOs;
using PrimePaper.Database.DataContract.Authorization.RAOs;
using PrimePaper.Database.Entities.People;

namespace PrimePaper.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                            //<-- Registration-oriented
            CreateMap<RegisterUserRequest, RegisterUserDTO>(); 
            CreateMap<RegisterUserDTO, RegisterUserRAO>();     //TODO: Need to work on improving our AutoMapper stuff ->  Action Handlers....Organize by theme
            CreateMap<RegisterUserRAO, UserEntity>();             
            CreateMap<LoginUserRequest, QueryForExistingUserDTO>();

                            //<-- Login-oriented
            CreateMap<QueryForExistingUserDTO, QueryForExistingUserRAO>();
            CreateMap<QueryForExistingUserRAO, UserEntity>();
            CreateMap<UserEntity, ReceivedExistingUserRAO>();
            CreateMap<ReceivedExistingUserRAO, ReceivedExistingUserDTO>();
            CreateMap<ReceivedExistingUserDTO, ReceivedExistingUserResponse>();
            CreateMap<LoginUserRequest, ReceivedExistingUserResponse>();

                            //--  Authcheck-oriented
            CreateMap<RegisterUserRAO, QueryForExistingUserRAO>();

        }
    }
}