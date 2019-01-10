using RedStarter.Business.DataContract.Application.DTOs;
using RedStarter.Business.DataContract.Contact;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.DataContract.Application.Interfaces
{
    public interface IContactManager
    {
        Task<bool> ContactCreate(ContactCreateDTO rao);

        Task<bool> EditContact(ContactEditDTO dto);

    }
}
