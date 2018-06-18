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
            using (var _groceryRepoItems = new GroceryContext())
            {
                return View(_groceryRepoItems.GroceryItems.ToArray());
            }
        }

        [HttpPost]
        public ActionResult Plant(string Item)
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
        public ActionResult Recipes(string Item)
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
        public ActionResult ShoppingCart(bool checkout)
        {
            if (ModelState.IsValid && checkout == true)
            {
                using (var _shoppingCartItems = new GroceryContext())
                {
                    foreach(var item in _shoppingCartItems.ShoppingCartItems)
                    {
                        _shoppingCartItems.ShoppingCartItems.Remove(item);
                    }
                    _shoppingCartItems.SaveChanges();
                }
            }
            ViewBag.Message = "Thank You For Shopping With Us!";
            return View();
        }

        [HttpPost]
        public ActionResult ShoppingCart(int ItemId, string math)
        {
            if (ModelState.IsValid)
            {
                using (var _shoppingCartItems = new GroceryContext())
                {
                    Items inventoryItem = _shoppingCartItems.GroceryItems.SingleOrDefault(m => m.Id == ItemId);
                    ShoppingCartItem itemRemove = _shoppingCartItems.ShoppingCartItems.FirstOrDefault(m => m.ItemId == ItemId);
                    ShoppingCartItem cartItem = new ShoppingCartItem
                    {
                        Item = inventoryItem
                    };
                    if (math == "add")
                    {
                        _shoppingCartItems.ShoppingCartItems.Add(cartItem);
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
                    return RedirectToAction("ShoppingCart");
                }
            }
            return View();
        }
    }
}


