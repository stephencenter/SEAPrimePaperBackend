using System.Threading.Tasks;

namespace PrimePaper.Business.DataContract.Cart
{
    public interface ICartManager
    {
        Task<bool> CreateCartItem(CartCreateDTO dto);
        Task<bool> EditCartItem(CartEditDTO dto);
        Task<bool> DeleteCartItem(int id);
    }
}
