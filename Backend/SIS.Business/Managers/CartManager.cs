using AutoMapper;
using PrimePaper.Business.DataContract.Cart;
using PrimePaper.Database.DataContract.Cart;
using PrimePaper.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Business.Managers
{
    public class CartManager : ICartManager
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _repository;

        public CartManager(IMapper mapper, ICartRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
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
    }
}
