using System.Threading.Tasks;

namespace PrimePaper.Business.DataContract.Cart
{
    public interface ICartManager
    {
        Task<bool> CreateProduct(CartCreateDTO dto);
    }
}
