using RedStarter.Business.DataContract.Contact;
using RedStarter.Business.DataContract.Contact.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.DataContract.Contact.Interfaces
{
    public interface IContactManager
    {
        Task<bool> ContactCreate(ContactCreateDTO rao);

        Task<bool> EditContact(ContactEditDTO dto);

    }
}
