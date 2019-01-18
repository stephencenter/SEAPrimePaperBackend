using AutoMapper;
using PrimePaper.Business.DataContract.Cart;
using PrimePaper.Business.Engines;
using PrimePaper.Database.DataContract.Cart;
using PrimePaper.Database.DataContract.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimePaper.Business.Managers
{
    public class CartManager : ICartManager 
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _repository;
        private readonly IProductRepository _productRepository;

        public CartManager(IMapper mapper, ICartRepository repository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<bool> CreateCartItem(CartCreateDTO dto)
        {
            var rao = _mapper.Map<CartCreateRAO>(dto);

            if (await _repository.CreateCartItem(rao))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> EditCartItem(CartEditDTO dto)
        {
            var rao = _mapper.Map<CartEditRAO>(dto);

            if (await _repository.EditCartItem(rao))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteCartItem(int id)
        {
            if (await _repository.DeleteCartItem(id))
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<CartGetDTO>> GetCartItems(int user_id)
        {
            // Need to get the ProductName and Price to map in to the cartListdto
            var rao = await _repository.GetCartItems(user_id);
            var list_of_dtos = _mapper.Map<IEnumerable<CartGetDTO>>(rao);

            foreach(var r in list_of_dtos)
            {
                var productrao = await _productRepository.GetProductById(r.ProductEntityId);
                r.ProductName = productrao.ProductName;
                r.Price = productrao.Price;
            }

            // We have to calculate the subtotal after we set the prices
            double subtotal = CartEngine.CalculateSubtotal(list_of_dtos);
            foreach (var r in list_of_dtos)
            {
                r.Subtotal = subtotal;
            }

            return list_of_dtos;
        }
    }
}
