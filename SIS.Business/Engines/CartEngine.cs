using PrimePaper.Business.DataContract.Cart;
using System.Collections.Generic;

namespace PrimePaper.Business.Engines
{
    public static class CartEngine
    {
        public static double CalculateSubtotal(IEnumerable<CartGetDTO> cart)
        {
            double subtotal = 0;

            foreach (CartGetDTO dto in cart)
            {
                subtotal += dto.Price*dto.Quantity;
            }

            return subtotal;
        }
    }
}
