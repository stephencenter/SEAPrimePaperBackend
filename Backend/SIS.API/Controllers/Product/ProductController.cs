using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimePaper.API.DataContract.Product;
using PrimePaper.Business.DataContract.Product;

namespace PrimePaper.API.Controllers.Product
{
    [AllowAnonymous]
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
        // [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateProduct(ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<ProductCreateDTO>(request);
            dto.DateCreated = DateTime.Now;

            if (await _manager.CreateProduct(dto))
            {
                return StatusCode(201);
            }

            throw new Exception();
        }

        [HttpPut]
        // [Authorize(Roles ="Admin")]
        public async Task<IActionResult> EditProduct(ProductEditRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<ProductEditDTO>(request);

            if (await _manager.EditProduct(dto))
            {
                return StatusCode(201);
            }

            throw new Exception();
        }

        [HttpDelete("{id}")]
        // [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            if (await _manager.DeleteProduct(id))
            {
                return StatusCode(201);
            }

            throw new Exception();
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetProducts();
            var response = _mapper.Map<IEnumerable<ProductResponse>>(dto);

            return Ok(response); //TODO : Handle exceptions
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetProductById(id);
            var response = _mapper.Map<ProductResponse>(dto);

            return Ok(response); //TODO : Handle exceptions
        }
    }
}