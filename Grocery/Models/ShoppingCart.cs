using System.Collections.Generic;

namespace Grocery.Models
{
    public class ShoppingCart
    {
        public List<Items> ShoppingCartItems { get; set; }
        public int ShoppingCartId { get; set; }

        public int Count()
        {
            return ShoppingCartItems.Count;
        }
    }
}