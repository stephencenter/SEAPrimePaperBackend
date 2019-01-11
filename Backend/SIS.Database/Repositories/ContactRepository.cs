using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrimePaper.Database.Contexts;
using PrimePaper.Database.DataContract.Application;
using PrimePaper.Database.Entities.Application;
using PrimePaper.Database.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Database.Contact
{
    public class ContactRepository : IContactRepository
    {
        private readonly SISContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public ContactRepository(SISContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateContact(ContactCreateRAO rao)
        {
            var entity = _mapper.Map<ContactEntity>(rao);
            await _context.ContactTableAccess.AddAsync(entity);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> EditContact(ContactEditRAO rao)
        {
            var entity = _mapper.Map<ContactEntity>(rao);
            _context.ContactTableAccess.Update(entity);
            return await _context.SaveChangesAsync() == 1;

        }

        public async Task<IEnumerable<ContactListItemRAO>> GetAllContacts()
        {
            var EntityList = await _context.ContactTableAccess.ToArrayAsync();
            var List = _mapper.Map<IEnumerable<ContactListItemRAO>>(EntityList);

            return List;
        }
    }
}