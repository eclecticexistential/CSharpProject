using Grocery.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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
        //public DbSet<Recipe> Recipes {get; set;}  <-- wanted to do initially, however, seeding database with items??
        // i.e. {Id = 0; Name = "Potato Soup"; Items = {} } <-- seeding a database with recipe items???
    }
}