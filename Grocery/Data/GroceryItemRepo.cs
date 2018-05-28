using Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery.Data
{
    public class GroceryItemRepo
    {
        private static Meats[] _meats = new Meats[]
        {
            new Meats()
            {
                Id = 0,
                ItemName = "Bacon",
                Animal = "Pig",
                Price = 2,
                Description = "Tasty pork product. Price per lbs."
            },
            new Meats()
            {
                Id = 1,
                ItemName = "Baloney",
                Animal = "Pig",
                Price = 1,
                Description = "Eat fried or straight out of the package. Price per unit."
            },
            new Meats()
            {
                Id = 2,
                ItemName = "Beef Ribs",
                Animal = "Cow",
                Price = 13,
                Description = "Ribs are finger licking good. Price per slab."
            },
            new Meats()
            {
                Id = 3,
                ItemName = "Beef Tbone Steak",
                Animal = "Cow",
                Price = 4,
                Description = "Great grilled or baked. Price per lbs."
            },
            new Meats()
            {
                Id = 4,
                ItemName = "Brisket",
                Animal = "Cow",
                Price = 11,
                Description = "Slow cook to perfection. Price per unit."
            },
            new Meats()
            {
                Id = 5,
                ItemName = "Chicken Breast",
                Animal = "Chicken",
                Price = 3,
                Description = "Grill or bake for best results. Price per lbs."
            },
            new Meats()
            {
                Id = 6,
                ItemName = "Chicken Strips",
                Animal = "Chicken",
                Price = 2,
                Description = "Great pan fried. Price per lbs."
            },
            new Meats()
            {
                Id = 7,
                ItemName = "Chicken Whole",
                Animal = "Chicken",
                Price = 15,
                Description = "Better than getting a bucket's worth. Price per unit."
            },
            new Meats()
            {
                Id = 8,
                ItemName = "Chicken Wings",
                Animal = "Chicken",
                Price = 2,
                Description = "All the spice combinations. Price per lbs."
            },
            new Meats()
            {
                Id = 9,
                ItemName = "Ham",
                Animal = "Pig",
                Price = 18,
                Description = "Bake in oven for supreme deliciousness. Price per unit."
            },
            new Meats()
            {
                Id = 10,
                ItemName = "Hamburger",
                Animal = "Cow",
                Price = 3,
                Description = "80/20. Price per lbs."
            },
            new Meats()
            {
                Id = 11,
                ItemName = "Hot Dogs",
                Animal = "Pig",
                Price = 1,
                Description = "Grill or boil to enhance meal. Price per unit."
            },
            new Meats()
            {
                Id = 12,
                ItemName = "Pork Chops",
                Animal = "Pig",
                Price = 2,
                Description = "Bake to enhance flavor. Price per lbs."
            },
            new Meats()
            {
                Id = 13,
                ItemName = "Pork Tenderloin",
                Animal = "Pig",
                Price = 9,
                Description = "Scrumptious. Price per unit."
            },
            new Meats()
            {
                Id = 14,
                ItemName = "Rib Eye Steak",
                Animal = "Cow",
                Price = 4,
                Description = "Marbled beef. Price per lbs."
            },
            new Meats()
            {
                Id = 15,
                ItemName = "Salmon Can",
                Animal = "Fish",
                Price = 2,
                Description = "Great for salmon croquet. Price per unit."
            },
            new Meats()
            {
                Id = 16,
                ItemName = "Salmon Raw",
                Animal = "Fish",
                Price = 2,
                Description = "Best pan fried or baked. Price per lbs."
            },
            new Meats()
            {
                Id = 17,
                ItemName = "Top Sirloin Steak",
                Animal = "Cow",
                Price = 4,
                Description = "Awesome treat yo' self food. Price per lbs."
            },
            new Meats()
            {
                Id = 18,
                ItemName = "Tuna Can",
                Animal = "Fish",
                Price = 1,
                Description = "Great for sandwiches or dip. Price per unit."
            },
            new Meats()
            {
                Id = 19,
                ItemName = "Turkey Sliced",
                Animal = "Turkey",
                Price = 2,
                Description = "Don't let this dry out. Price per unit."
            },
            new Meats()
            {
                Id = 20,
                ItemName = "Turkey Whole",
                Animal = "Turkey",
                Price = 18,
                Description = "Do not under cook. Price per unit."
            },
        };
        public Meats[] GetMeats()
        {
            return _meats;
        }
        public Meats GetMeats(int id)
        {
            Meats meatsToReturn = null;
            foreach (var meat in _meats)
            {
                if (meat.Id == id)
                {
                    meatsToReturn = meat;
                    break;
                }
            }
            return meatsToReturn;
        }
        public List<string> GetMeatType()
        {
            var meatTypeList = new List<string> { };
            foreach (var meatTypes in _meats)
            {
                meatTypeList.Add(meatTypes.Animal);
            }
            return meatTypeList;
        }
    }
}