using System.Collections.Generic;

namespace Grocery.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItems = new List<Items>();
        }

        public int Id { get; set; }

        public ICollection<Items> CartItems { get; set; }
        
    }
}