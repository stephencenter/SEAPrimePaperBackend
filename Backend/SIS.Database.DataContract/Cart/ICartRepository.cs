using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimePaper.Database.DataContract.Cart
{
    public interface ICartRepository
    {
        Task<bool> CreateCartItem(CartCreateRAO rao);
        Task<bool> EditCartItem(CartEditRAO rao);
        Task<bool> DeleteCartItem(int id);
        Task<IEnumerable<CartGetRAO>> GetCartItems(int user_id);
    }
}
