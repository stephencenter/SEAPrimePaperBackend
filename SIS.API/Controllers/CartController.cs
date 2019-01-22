using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrimePaper.API.DataContract.Cart;
using PrimePaper.Business.DataContract.Cart;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

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

        [HttpPut]
        public async Task<IActionResult> EditCartItem([FromBody]CartEditRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<CartEditDTO>(request);

            if (await _manager.EditCartItem(dto))
            {
                return StatusCode(201);
            }

            throw new Exception();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            if (await _manager.DeleteCartItem(id))

            {
                return StatusCode(201);
            }

            throw new Exception();
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var user_id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var dto = await _manager.GetCartItems(user_id);
            var response = _mapper.Map<IEnumerable<CartResponse>>(dto);

            return Ok(response); //TODO : Handle exceptions
        }
    }
}
