using Grocery.Models;
using System;
using System.Collections.Generic;
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
                ViewBag._shoppingCart = _shoppingCart.ShoppingCartItems.ToArray();
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
                   var item = _groceryRepoItems.ShoppingCartItems.SingleOrDefault(m => m.Id == id);
                   if (item == null)
                    {
                        Items inventory = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.Id == id);
                        ShoppingCartItem addThis = new ShoppingCartItem
                        {
                            Item = inventory
                        };
                        _groceryRepoItems.ShoppingCartItems.Add(addThis);
                        _groceryRepoItems.SaveChanges();
                    }
                    else
                    {
                        //int ogPrice = item.Price / item.Amount;
                        //item.Amount += 1;
                        //item.Price += ogPrice;
                        //change amount and price
                    }
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
                    var item = _groceryRepoItems.ShoppingCartItems.SingleOrDefault(m => m.Id == id);
                    if (item == null)
                    {
                            var inventory = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.Id == id);
                            ShoppingCartItem addThis = new ShoppingCartItem
                            {
                                Item = inventory
                            };
                            _groceryRepoItems.ShoppingCartItems.Add(addThis);
                            _groceryRepoItems.SaveChanges();
                    }
                    else
                    {
                        //int ogPrice = item.Price / item.Amount;
                        //item.Amount += 1;
                        //item.Price += ogPrice;
                        //change amount and price
                    }
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
                    var item = _groceryRepoItems.ShoppingCartItems.SingleOrDefault(m => m.Id == id);
                    if (item == null)
                    {
                        var inventory = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.Id == id);
                        ShoppingCartItem addThis = new ShoppingCartItem
                        {
                            Item = inventory
                        };
                        _groceryRepoItems.SaveChanges();
                    }
                    else
                    {
                        //int ogPrice = item.Price / item.Amount;
                        //item.Amount += 1;
                        //item.Price += ogPrice;
                        //change amount and price
                    }
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
                    var item = _groceryRepoItems.ShoppingCartItems.SingleOrDefault(m => m.Id == id);
                    if (item == null)
                    {
                            var inventory = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.Id == id);
                            ShoppingCartItem addThis = new ShoppingCartItem
                            {
                                Item = inventory
                            };
                            _groceryRepoItems.SaveChanges();
                    }
                    else
                    {
                        //int ogPrice = item.Price / item.Amount;
                        //item.Amount += 1;
                        //item.Price += ogPrice;
                        //change amount and price
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
            using (var _shoppingCart = new GroceryContext())
            {
                //var cartItems = _groceryRepoItems.GroceryItems.Include("ShoppingCartItems").Where(gi => gi.ShoppingCartItems.Any()); // use to identify only once in shoppingcart rather than show multiple times on shoppingcart view

                return View(_shoppingCart.ShoppingCartItems.ToArray());
            }
        }

        [HttpPost]
        public ActionResult ShoppingCart(int ItemId, string math)
        {
            if (ModelState.IsValid)
            {
                using (var _shoppingCartItems = new GroceryContext())
                {
                    var item = _shoppingCartItems.ShoppingCartItems.SingleOrDefault(m => m.Id == ItemId);
                    if (item != null)
                    {
                        if (math == "del")
                        {
                            _shoppingCartItems.ShoppingCartItems.Remove(item);
                            _shoppingCartItems.SaveChanges();
                        }
                        else if (math == "sub")
                        {
                            //int ogPrice = item.Price / item.Amount;
                            //item.Amount -= 1;
                            //if (item.Amount == 0)
                            //{
                            //    _shoppingCartItems.ShoppingCartItems.Remove(item);
                            //    return RedirectToAction("ShoppingCart");
                            //}
                            //item.Price -= ogPrice;
                        }
                        else if (math == "add")
                        {
                            //int ogPrice = item.Price / item.Amount;
                            //item.Amount += 1;
                            //item.Price += ogPrice;
                            //change amount and price
                        }
                    }
                    return RedirectToAction("ShoppingCart");
                }
            }
            return View();
        }
    }
}