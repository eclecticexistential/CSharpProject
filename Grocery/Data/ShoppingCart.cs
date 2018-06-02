using Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery.Data
{
    public class ShoppingCart
    {
        private List<Items> shoppingCartItems = new List<Items>();

        public List<Items> ItemsInCart { get { return shoppingCartItems; } }

        public List<Items> GetCartItems()
        {
            return shoppingCartItems;
        }

        public List<Items> ChangeShoppingCartItemAmount(int id, bool math)
        {
            foreach (var item in ItemsInCart)
            {
                if(item.Id == id)
                {
                    if (math)
                    {
                        item.Amount += 1;
                        item.Price += item.Price;
                        break;
                    }
                    else
                    {
                        if(item.Amount > 1)
                        {
                            item.Amount -= 1;
                            item.Price -= item.Price;
                            break;
                        }
                        if(item.Amount == 1)
                        {
                            return RemoveCartItem(item.Id);
                        }
                    }
                }

            }
            return ItemsInCart;
        }
        public List<Items> RemoveCartItem(int id)
        {
            foreach (var item in ItemsInCart)
            {
                if(item.Id == id)
                {
                    ItemsInCart.Remove(item);
                    break;
                }
            }
            return shoppingCartItems;
        }
    }
}