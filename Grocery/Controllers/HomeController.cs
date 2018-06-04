using Grocery.Data;
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
        private GroceryItemRepo _groceryItemRepo = null;
        private ShoppingCart _shoppingCart = null;

        public HomeController()
        {
            _groceryItemRepo = new GroceryItemRepo();
            _shoppingCart = new ShoppingCart();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Plant()
        {
            ViewBag.Message = "Food You Need to Feel Healthy and Live Well";
            var dasPlants = _groceryItemRepo.GetItems();
            return View(dasPlants);
        }

        [HttpPost]
        public ActionResult Plant(Items items)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _shoppingCart.ChangeShoppingCartItemAmount(items.Id, true);
                }
                catch
                {
                    var entry = GroceryItemRepo.GetItems(items.Id);
                    _shoppingCart.GetCartItems.Add(entry);
                }
            }
            return RedirectToAction("Plant");
        }


        public ActionResult Meat()
        {
            ViewBag.Message = "Animal Protein to Refuel";
            var dasMeats = _groceryItemRepo.GetItems();
            return View(dasMeats);
        }

        [HttpPost]
        public ActionResult Meat(Items items)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _shoppingCart.ChangeShoppingCartItemAmount(items.Id, true);
                }
                catch
                {
                    var entry = GroceryItemRepo.GetItems(items.Id);
                    _shoppingCart.GetCartItems.Add(entry);
                }
            }
            return RedirectToAction("Meat");
        }

        public ActionResult Baking()
        {
            ViewBag.Message = "Items You Need to Bake, Season, and Create Deliciousness";
            var dasBake = _groceryItemRepo.GetItems();
            return View(dasBake);
        }

        [ActionName("Baking"), HttpPost]
        public ActionResult BakingPost()
        {
            int id = Int32.Parse(Request.Form["Item"]);
            if (ModelState.IsValid)
            {
                //int currentAmount = _shoppingCart.Count();
                //if(currentAmount > 0)
                //{
                //    _shoppingCart.ChangeShoppingCartItemAmount(id, true);
                //}
                //else
                //{
                    var entry = GroceryItemRepo.GetItems(id);
                    _shoppingCart.AddItem(entry);
                //}
            }
            return View("ShoppingCart", _shoppingCart);
        }

        public ActionResult Recipes()
        {
            ViewBag.Message = "Meal Ideas to Spice Things Up";

            return View();
        }

        [HttpPost]
        public ActionResult Recipes(Items items)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _shoppingCart.ChangeShoppingCartItemAmount(items.Id, true);
                }
                catch
                {
                    var entry = GroceryItemRepo.GetItems(items.Id);
                    _shoppingCart.GetCartItems.Add(entry);
                }
            }
            return RedirectToAction("Recipes");
        }

        public ActionResult ShoppingCart()
        {
            ViewBag.Message = "Items in Your Shopping Cart";
            var dasCart = _shoppingCart.GetCartItems;
            int totalPrice = _shoppingCart.GetCartItems.Sum(e => e.Price);
            ViewBag.TotalPrice = totalPrice;
            return View(dasCart);
        }

        //[HttpPost]
        //public ActionResult ShoppingCart(Items items)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _shoppingCart.RemoveCartItem(items.Id);
        //    }
        //    return RedirectToAction("ShoppingCart", items);
        //}

        //[HttpPost]
        //public ActionResult ShoppingCart(Items items, bool math)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _shoppingCart.ChangeShoppingCartItemAmount(items.Id, math);
        //    }
        //    return RedirectToAction("ShoppingCart", items);
        //}
    }
}