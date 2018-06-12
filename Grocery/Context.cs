using Grocery.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Grocery
{
    public class Context : DbContext
    {
        public Context() : base("GroceryItems")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }
        public DbSet<Items> GroceryItems { get; set; }
    }
}