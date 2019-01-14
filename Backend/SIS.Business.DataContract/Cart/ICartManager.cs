using System.Threading.Tasks;

namespace PrimePaper.Business.DataContract.Cart
{
    public interface ICartManager
    {
        Task<bool> CreateCartItem(CartCreateDTO dto);
    }
}
