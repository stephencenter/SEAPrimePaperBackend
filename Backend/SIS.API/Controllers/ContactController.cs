using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrimePaper.API.DataContract.Contact;
using PrimePaper.Business.DataContract.Contact;
using PrimePaper.Business.DataContract.Contact.DTOs;
using PrimePaper.Business.DataContract.Contact.Interfaces;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PrimePaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactManager _contactCreateManager;
        private readonly IMapper _mapper;

        public ContactController(IContactManager contactCreateManager, IMapper mapper)
        {
            _contactCreateManager = contactCreateManager;
            _mapper = mapper;
        }

        [HttpPost] 
        public async Task<IActionResult> PostContact(ContactCreateRequest contactCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); 
            var dto = _mapper.Map<ContactCreateDTO>(contactCreateRequest);
            dto.OwnerId = identityClaimNum;

            if (await _contactCreateManager.ContactCreate(dto))
                return StatusCode(201); //TODO: Return URL of new resource

            return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> EditContact(ContactEditRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<ContactEditDTO>(request);

            if (await _contactCreateManager.EditContact(dto))
            {
                return StatusCode(201);
            }

            throw new Exception();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _contactCreateManager.GetContactById(id);
            var response = _mapper.Map<ContactResponse>(dto);

            return Ok(response); //TODO : Handle exceptions
        }
    }
}

