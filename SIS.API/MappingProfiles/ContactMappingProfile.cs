using AutoMapper;
using PrimePaper.API.DataContract.Contact;
using PrimePaper.Business.DataContract.Contact;
using PrimePaper.Business.DataContract.Contact.DTOs;
using PrimePaper.Database.DataContract.Application;
using PrimePaper.Database.Entities;

namespace PrimePaper.API.MappingProfiles
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
