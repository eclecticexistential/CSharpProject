using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery.Models
{
    public class Meats
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public string DisplayText
        {
            get
            {
                return ItemName;
            }
        }

        public string CoverImageFileName
        {
            get
            {
                return ItemName.Replace(" ", "").ToLower() + ".jpg";
            }
        }
    }

}