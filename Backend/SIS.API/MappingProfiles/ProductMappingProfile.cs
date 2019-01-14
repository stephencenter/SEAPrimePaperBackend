using AutoMapper;
using RedStarter.API.DataContract.Product;
using RedStarter.Business.DataContract.Product;
using RedStarter.Database.DataContract.Product;
using RedStarter.Database.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedStarter.API.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            // Product Create Mapping
            CreateMap<ProductCreateRequest, ProductCreateDTO>();
            CreateMap<ProductCreateDTO, ProductCreateRAO>();
            CreateMap<ProductCreateRAO, ProductEntity>();

            CreateMap<ProductEditRequest, ProductEditDTO>();
            CreateMap<ProductEditDTO, ProductEditRAO>();
            CreateMap<ProductEditRAO, ProductEntity>();

           
        }
    }
}
