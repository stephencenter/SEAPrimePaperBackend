using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Database.DataContract.Application
{
  public interface IContactRepository
    {
        Task<bool> CreateContact(ContactCreateRAO rao);

        Task<bool> EditContact(ContactEditRAO rao);

    }
}
