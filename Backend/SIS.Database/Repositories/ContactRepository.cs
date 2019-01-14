using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrimePaper.Database.Contexts;
using PrimePaper.Database.DataContract.Application;
using PrimePaper.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PrimePaper.Database.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly SISContext _context;
        private readonly IMapper _mapper;

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

        public async Task<ContactGetListItemRAO> GetContactById(int id)
        {
            var query = _context.ContactTableAccess.Single(x => x.ContactEntityId == id);
            var rao = _mapper.Map<ContactGetListItemRAO>(query);

            return rao;
        }

        public async Task<IEnumerable<ContactGetListItemRAO>> GetAllContacts()
        {
            var EntityList = await _context.ContactTableAccess.ToArrayAsync();
            var List = _mapper.Map<IEnumerable<ContactGetListItemRAO>>(EntityList);

            return List;
        }
    }
}