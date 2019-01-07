using AutoMapper;
using RedStarter.Business.DataContract.Product;
using RedStarter.Database.DataContract.Note;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.Product
{
    public class ProductManager : IProductManager
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public ProductManager(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<bool> CreateProduct(ProductCreateDTO dto)
        {
            ProductCreateRAO rao = _mapper.Map<ProductCreateRAO>(dto);

            await _repository.CreateProduct(rao);

            throw new NotImplementedException();
        }
    }
}
