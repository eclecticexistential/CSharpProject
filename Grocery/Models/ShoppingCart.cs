using Grocery.Data;
using System.Linq;
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

        public List<Items> AddItems(int id)
        {
            var curItem = shoppingCartItems.SingleOrDefault(p => p.Id == id);
            if (curItem != null)
            {
                int ogPrice = curItem.Price / curItem.Amount;
                curItem.Amount += 1;
                curItem.Price += ogPrice;
            }
            else
            {
                var item = GroceryItemRepo.GetItem(id);
                shoppingCartItems.Add(item);
            }
            return shoppingCartItems;
        }

        public List<Items> DeductItem(int id)
        {
            var curItem = shoppingCartItems.SingleOrDefault(p => p.Id == id);
            if (curItem != null)
            {
                int ogPrice = curItem.Price / curItem.Amount;
                curItem.Amount -= 1;
                curItem.Price -= ogPrice;
                if (curItem.Amount == 0)
                {
                    RemoveCartItem(curItem.Id);
                }
            }
            return shoppingCartItems;
        }
        
        public List<Items> RemoveCartItem(int id)
        {
            var curItem = shoppingCartItems.SingleOrDefault(p => p.Id == id);
            if (curItem != null)
            {
                shoppingCartItems.Remove(curItem);
            }
            return shoppingCartItems;
        }
    }
}