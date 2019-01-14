using PrimePaper.API.DataContract.Cart;
using PrimePaper.Business.DataContract.Cart;
using PrimePaper.Database.DataContract.Cart;
using PrimePaper.Database.Entities;
using AutoMapper;

namespace PrimePaper.API.MappingProfiles
{
    public class CartMappingProfile : Profile
    {
        public CartMappingProfile()
        {
            // Cart Mapping
            CreateMap<CartCreateRequest, CartCreateDTO>();
            CreateMap<CartCreateDTO, CartCreateRAO>();
            CreateMap<CartCreateRAO, CartEntity>();

            CreateMap<CartEditRequest, CartEditDTO>();
            CreateMap<CartEditDTO, CartEditRAO>();
            CreateMap<CartEditRAO, CartEntity>();
        }
    }
}
