using RedStarter.Database.DataContract.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Database.DataContract.Application
{
  public interface IContactRepository
    {
        Task<bool> CreateContact(ContactCreateRAO rao);

        Task<bool> EditContact(ContactEditRAO rao);

        Task<Product.ContactGetListItemRAO> GetContactById(int id);

    }
}
