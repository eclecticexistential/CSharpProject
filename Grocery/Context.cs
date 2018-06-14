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
    }
}