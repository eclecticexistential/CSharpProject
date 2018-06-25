using Grocery.Models;
using System.Data.Entity;

namespace Grocery
{
    public class GroceryContext : DbContext
    {
       public GroceryContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        public DbSet<Items> GroceryItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<RecipeItems> ListOfRecipes { get; set; }
    }
}