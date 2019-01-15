using System.Threading.Tasks;

namespace PrimePaper.Database.DataContract.Application
{
    public interface IContactRepository
    {
        Task<bool> CreateContact(ContactCreateRAO rao);
        Task<bool> EditContact(ContactEditRAO rao);
        Task<ContactGetListItemRAO> GetContactById(int id);

    }
}