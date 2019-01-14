using RedStarter.Business.DataContract.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Database.DataContract.Product
{
   public interface IProductRepository
    {
        Task<bool> CreateProduct(ProductCreateRAO rao);
        Task<bool> EditProduct(ProductEditRAO rao);
        Task<IEnumerable<ContactGetListItemRAO>> GetProducts();
        Task<ContactGetListItemRAO> GetProductById(int id);
        Task<bool> DeleteProduct(int id);

    }
}
