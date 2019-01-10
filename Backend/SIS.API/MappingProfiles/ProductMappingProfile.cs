using AutoMapper;
using PrimePaper.API.DataContract.Product;
using PrimePaper.Business.DataContract.Product;
using PrimePaper.Database.DataContract.Product;
using PrimePaper.Database.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimePaper.API.MappingProfiles
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
           
        }
    }
}
