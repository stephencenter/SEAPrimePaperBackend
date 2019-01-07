using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedStarter.API.DataContract.Product;
using RedStarter.Business.DataContract.Product;

namespace RedStarter.API.Controllers.Product
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductCreateRequest request)
        {
            var dto = _mapper.Map<ProductCreateDTO>(request);
            dto.DateCreated = DateTime.Now;

            return Ok();
        }
        
    }
}