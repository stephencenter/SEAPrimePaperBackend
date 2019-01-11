using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrimePaper.API.DataContract.Cart;
using PrimePaper.Business.DataContract.Cart;
using System;
using System.Threading.Tasks;

namespace PrimePaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICartManager _manager;

        public CartController(IMapper mapper, ICartManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartItem(CartCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<CartCreateDTO>(request);

            if (await _manager.CreateProduct(dto))
            {
                return StatusCode(201);
            }

            throw new Exception();
        }
    }
}
