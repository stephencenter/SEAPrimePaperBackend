using AutoMapper;
using PrimePaper.Business.DataContract.Product;
using PrimePaper.Database.DataContract.Product;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimePaper.Business.Managers
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

        public async Task<bool> DeleteProduct(int id)
        {
            if (await _repository.DeleteProduct(id))
            {
                return true;
            }

            return false;
        }

        public async Task<ProductGetDTO> GetProductById(int id)
        {
            var rao = await _repository.GetProductById(id);
            var dto = _mapper.Map<ProductGetDTO>(rao);

            return dto;
        }

        public async Task<IEnumerable<ProductGetDTO>> GetProducts()
        {
            var rao = await _repository.GetProducts();
            var dto = _mapper.Map<IEnumerable<ProductGetDTO>>(rao);

            return dto;
        }
    }
}
