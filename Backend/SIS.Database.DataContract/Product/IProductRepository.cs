using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimePaper.Database.DataContract.Product
{
    public interface IProductRepository
    {
        Task<bool> CreateProduct(ProductCreateRAO rao);
        Task<bool> EditProduct(ProductEditRAO rao);
        Task<bool> DeleteProduct(int id);
        Task<IEnumerable<ProductGetRAO>> GetProducts();
        Task<ProductGetRAO> GetProductById(int id);
    }
}
