using AutoMapper;
using RedStarter.API.DataContract.Contact;
using RedStarter.Business.DataContract.Contact;
using RedStarter.Business.DataContract.Contact.DTOs;
using RedStarter.Database.DataContract.Application;
using RedStarter.Database.Entities.Application;

namespace RedStarter.API.MappingProfiles
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            //<-- Registration-oriented
            CreateMap<ContactCreateRequest, ContactCreateDTO>(); 
            CreateMap<ContactCreateDTO, ContactCreateRAO>();     
            CreateMap<ContactCreateRAO, ContactEntity>();

            CreateMap<ContactEditRequest, ContactEditDTO>();
            CreateMap<ContactEditDTO, ContactEditRAO>();

        }
    }
}
