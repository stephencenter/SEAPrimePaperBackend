using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.DataContract.Product
{
    public interface IProductManager
    {
        Task<bool> CreateProduct(ProductCreateDTO dto);
    }
}
