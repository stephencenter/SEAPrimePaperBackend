using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.DataContract.Product
{
    public interface IProductManager
    {
        Task<bool> CreateProduct(ProductCreateDTO dto);
        Task<bool> EditProduct(ProductEditDTO dto);
        Task<IEnumerable<ProductGetListItemDTO>> GetProducts(); //preexisting so no 
        Task<ProductGetListItemDTO> GetProductById(int id);
        Task<bool> DeleteProduct(int id);
    }
}
