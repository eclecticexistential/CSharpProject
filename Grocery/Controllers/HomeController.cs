using Grocery.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Grocery.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            //creates shopping cart array for viewbag prop
            using (var _shoppingCart = new GroceryContext())
            {
                var shoppingCartQuery = from ci in _shoppingCart.ShoppingCartItems select ci;
                var shoppingCartList = shoppingCartQuery.ToList();
                ViewBag._shoppingCart = shoppingCartList.ToArray();
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Plant()
        {
            ViewBag.Message = "Food You Need to Feel Healthy and Live Well";
            //loads plant page with full array of grocery items
            using (var _groceryRepoItems = new GroceryContext())
            {
                return View(_groceryRepoItems.GroceryItems.ToArray());
            }
        }

        [HttpPost]
        public ActionResult Plant(string Item)
        {
            //gets id number from string post
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                using (var _groceryRepoItems = new GroceryContext())
                {
                    Items inventoryItem = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.Id == id);
                    ShoppingCartItem addThis = new ShoppingCartItem
                    {
                        Item = inventoryItem
                    };
                    _groceryRepoItems.ShoppingCartItems.Add(addThis);
                    inventoryItem.Quantity -= 1;
                    _groceryRepoItems.SaveChanges();
                }
                return RedirectToAction("Plant");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Meat()
        {
            ViewBag.Message = "Animal Protein to Refuel";
            using (var _groceryRepoItems = new GroceryContext())
            {
                return View(_groceryRepoItems.GroceryItems.ToArray());
            }
        }

        [HttpPost]
        public ActionResult Meat(string Item)
        {
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                using (var _groceryRepoItems = new GroceryContext())
                {
                    Items inventoryItem = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.Id == id);
                    ShoppingCartItem addThis = new ShoppingCartItem
                    {
                        Item = inventoryItem
                    };
                    _groceryRepoItems.ShoppingCartItems.Add(addThis);
                    inventoryItem.Quantity -= 1;
                    _groceryRepoItems.SaveChanges();
                }
                return RedirectToAction("Meat");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Baking()
        {
            ViewBag.Message = "Items You Need to Bake, Season, and Create Deliciousness";
            using (var _groceryRepoItems = new GroceryContext())
            {
                return View(_groceryRepoItems.GroceryItems.ToArray());
            }
        }

        [HttpPost]
        public ActionResult Baking(string Item)
        {
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                using (var _groceryRepoItems = new GroceryContext())
                {
                    Items inventoryItem = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.Id == id);
                    ShoppingCartItem addThis = new ShoppingCartItem
                    {
                        Item = inventoryItem
                    };
                    _groceryRepoItems.ShoppingCartItems.Add(addThis);
                    inventoryItem.Quantity -= 1;
                    _groceryRepoItems.SaveChanges();
                }
                return RedirectToAction("Baking");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Recipes()
        {
            ViewBag.Message = "Meal Ideas to Spice Things Up";

            return View();
        }

        [HttpPost]
        public ActionResult Recipes(string Items)
        {
            //needs work. Id numbers do not function as expected on Recipes page, however, strings do.
            if (ModelState.IsValid)
            {
                using (var _groceryRepoItems = new GroceryContext())
                {
                    if(Items == "potato")
                    {
                        List<string> potatoSoupIds = new List<string> { "Potato", "Milk", "Butter", "Pepper", "Salt", "Bacon", "Celery", "Onion", "Vegetable Broth" };
                        foreach (var name in potatoSoupIds)
                        {
                            Items inventoryItem = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.ItemName == name);
                            ShoppingCartItem addThis = new ShoppingCartItem
                            {
                                Item = inventoryItem
                            };
                            _groceryRepoItems.ShoppingCartItems.Add(addThis);
                            inventoryItem.Quantity -= 1;
                            _groceryRepoItems.SaveChanges();
                        }
                    }
                }
                return RedirectToAction("Recipes");
            }
            else
            {
                return View();
            }
        }

        public ActionResult ShoppingCart()
        {
            ViewBag.Message = "Items in Your Shopping Cart";
            return View();
        }

        [HttpPost]
        public ActionResult ShoppingCart(int ItemId, string math)
        {
            if (ModelState.IsValid)
            {
                using (var _shoppingCartItems = new GroceryContext())
                {
                    //gets the item from inventory
                    Items inventoryItem = _shoppingCartItems.GroceryItems.SingleOrDefault(m => m.Id == ItemId);
                    //finds item to be removed
                    ShoppingCartItem itemRemove = _shoppingCartItems.ShoppingCartItems.FirstOrDefault(m => m.ItemId == ItemId);
                    //transforms inventory item to shopping cart item
                    ShoppingCartItem cartItem = new ShoppingCartItem
                    {
                        Item = inventoryItem
                    };
                    if (math == "add")
                    {
                        _shoppingCartItems.ShoppingCartItems.Add(cartItem);
                        //logic for when quantity reduction goes over quantity amount is not yet created.
                        inventoryItem.Quantity -= 1;
                        _shoppingCartItems.SaveChanges();
                    }
                    else if (math == "sub")
                    {
                        _shoppingCartItems.ShoppingCartItems.Remove(itemRemove);
                        inventoryItem.Quantity += 1;
                        _shoppingCartItems.SaveChanges();
                        
                    }
                    else if (math == "del")
                    {
                        //removes all instances of item in shopping cart. probably a better way to do this.
                        foreach(var item in _shoppingCartItems.ShoppingCartItems)
                        {
                            if(item.ItemId == ItemId)
                            {
                                _shoppingCartItems.ShoppingCartItems.Remove(item);
                                inventoryItem.Quantity += 1;
                            }
                        }
                        _shoppingCartItems.SaveChanges();
                    }
                    //deletes all items from shopping cart. ItemId is a potential placemarker for shopping cart id
                    else if (math == "checkout" && ItemId == 000)
                    {
                        foreach (var item in _shoppingCartItems.ShoppingCartItems)
                        {
                            _shoppingCartItems.ShoppingCartItems.Remove(item);
                        }
                        _shoppingCartItems.SaveChanges();
                    }
                    return RedirectToAction("ShoppingCart");
                }
            }
            return View();
        }
    }
}


