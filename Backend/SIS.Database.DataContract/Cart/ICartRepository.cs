using System.Threading.Tasks;

namespace PrimePaper.Database.DataContract.Cart
{
    public interface ICartRepository
    {
        Task<bool> CreateCartItem(CartCreateRAO rao);
    }
}
