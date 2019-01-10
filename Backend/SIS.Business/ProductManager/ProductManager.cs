using AutoMapper;
using RedStarter.Business.DataContract.Product;
using RedStarter.Database.DataContract.Product;
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
            var rao = _mapper.Map<ProductCreateRAO>(dto);

            if (await _repository.CreateProduct(rao))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> EditProduct(ProductEditDTO dto)
        {
            var rao = _mapper.Map<ProductEditRAO>(dto);

            if (await _repository.EditProduct(rao))
            {
                return true;
            }

            return false;
        }

        public async Task<ProductGetListItemDTO> GetProductById(int id)
        {
            var rao = await _repository.GetProductById(id);
            var dto = _mapper.Map<ProductGetListItemDTO>(rao);

            return dto;
        }

        public async Task<IEnumerable<ProductGetListItemDTO>> GetProducts()
        {
            var rao = await _repository.GetProducts();
            var dto = _mapper.Map<IEnumerable<ProductGetListItemDTO>>(rao);

            return dto;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            if (await _repository.DeleteProduct(id))
            {
                return true;
            }

            return false;
        }
    }
}
