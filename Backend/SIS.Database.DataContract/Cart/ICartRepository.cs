using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Database.DataContract.Cart
{
    public interface ICartRepository
    {
        Task<bool> CreateCartItem(CartCreateRAO rao);
    }
}
