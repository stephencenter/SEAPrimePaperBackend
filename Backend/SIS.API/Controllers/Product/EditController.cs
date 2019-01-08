using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedStarter.API.DataContract.Product;
using RedStarter.Business.DataContract.Product;

namespace RedStarter.API.Controllers.Product
{
    [Route("api/Product/[controller]")]
    [ApiController]
    public class EditController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductManager _manager;

        public EditController(IMapper mapper, IProductManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductEditRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var dto = _mapper.Map<ProductEditDTO>(request);

            if (await _manager.EditProduct(dto))
            {
                return StatusCode(201);
            }

            throw new Exception();
        }
    }
}