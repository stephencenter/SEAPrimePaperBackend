using PrimePaper.Business.DataContract.Contact;
using PrimePaper.Business.DataContract.Contact.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Business.DataContract.Contact.Interfaces
{
    public interface IContactManager
    {
        Task<bool> ContactCreate(ContactCreateDTO rao);

        Task<bool> EditContact(ContactEditDTO dto);

    }
}
