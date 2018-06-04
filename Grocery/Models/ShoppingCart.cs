using System.Collections.Generic;

namespace Grocery.Models
{
    public class ShoppingCart
    {
        private List<Items> shoppingCartItems = new List<Items>();

        public List<Items> GetCartItems { get { return shoppingCartItems; } }

        public void AddItem(Items item)
        {
            shoppingCartItems.Add(item);
        }

        public int Count()
        {
            return shoppingCartItems.Count;
        } 

        public List<Items> ChangeShoppingCartItemAmount(int id, bool math)
        {
            foreach (var item in GetCartItems)
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
            return GetCartItems;
        }
        public List<Items> RemoveCartItem(int id)
        {
            foreach (var item in GetCartItems)
            {
                if(item.Id == id)
                {
                    GetCartItems.Remove(item);
                    break;
                }
            }
            return shoppingCartItems;
        }
    }
}