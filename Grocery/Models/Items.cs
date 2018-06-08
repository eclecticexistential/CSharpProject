using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

        public string CoverImageFileName => ItemName.Replace(" ", "").ToLower() + ".jpg";
    }

}