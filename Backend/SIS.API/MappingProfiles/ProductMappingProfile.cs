using AutoMapper;
using PrimePaper.API.DataContract.Product;
using PrimePaper.Business.DataContract.Product;
using PrimePaper.Database.DataContract.Product;
using PrimePaper.Database.Entities.Product;

namespace PrimePaper.API.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            // Product Mapping
            CreateMap<ProductCreateRequest, ProductCreateDTO>();
            CreateMap<ProductCreateDTO, ProductCreateRAO>();
            CreateMap<ProductCreateRAO, ProductEntity>();

            CreateMap<ProductEditRequest, ProductEditDTO>();
            CreateMap<ProductEditDTO, ProductEditRAO>();
            CreateMap<ProductEditRAO, ProductEntity>();
        }
    }
}
