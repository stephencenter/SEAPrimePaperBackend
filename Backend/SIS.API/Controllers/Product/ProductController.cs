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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductManager _manager;

        public ProductController(IMapper mapper, IProductManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        [HttpPost]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> PostProduct(ProductCreateRequest request)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var dto = _mapper.Map<ProductCreateDTO>(request);
            dto.DateCreated = DateTime.Now;
            dto.OwnerId = identityClaimNum;


            if (await _manager.CreateProduct(dto))
                return StatusCode(201);
            throw new Exception();
        }
        
    }
}