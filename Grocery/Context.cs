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
        public GroceryContext() : base("name=GroceryItems")
        {
        }
        public DbSet<Items> GroceryItems { get; set; }
    }

    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext() : base("name = CartItems")
        {
        }
        public DbSet<Items> ShoppingCartItems { get; set; }
    }
}