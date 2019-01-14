using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrimePaper.API.DataContract.Cart;
using PrimePaper.Business.DataContract.Cart;
using System;
using System.Security.Claims;
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

            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var dto = _mapper.Map<CartCreateDTO>(request);
            dto.OwnerId = identityClaimNum;

            if (await _manager.CreateCartItem(dto))
            {
                return StatusCode(201);
            }

            throw new Exception();
        }
    }
}
