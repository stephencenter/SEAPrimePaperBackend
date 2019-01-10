using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RedStarter.API.DataContract.Contact;
using RedStarter.Business.DataContract.Contact.DTOs;
using RedStarter.Business.DataContract.Contact.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RedStarter.API.Controllers.Contact
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

            var created = await _contactCreateManager.ContactCreate(dto);

            if (created)
                return StatusCode(201); //TODO: Return URL of new resource

            return StatusCode(500);
        }
    }
}

