using Grocery.Data;
using System.Collections.Generic;

namespace Grocery.Models
{
    public class ShoppingCart
    {
        private List<Items> shoppingCartItems = new List<Items>();
        public Items[] ShowItems()
        {
            return shoppingCartItems.ToArray();
        }

        public int Count()
        {
            return shoppingCartItems.Count;
        }

        public List<Items> AddItems(Items item)
        {
            if(shoppingCartItems.Count > 0)
            {
                foreach (var itemsInCart in shoppingCartItems)
                {
                    if (item.Id == itemsInCart.Id)
                    {
                        itemsInCart.Amount += 1;
                        itemsInCart.Price += itemsInCart.Price;
                        break;
                    }
                }
            }
            else
            {
                shoppingCartItems.Add(item);
            }
            return shoppingCartItems;
        }
        
        public List<Items> RemoveCartItem(int id)
        {
            foreach (var item in shoppingCartItems)
            {
                if(item.Id == id)
                {
                    shoppingCartItems.Remove(item);
                    break;
                }
            }
            return shoppingCartItems;
        }
    }
}