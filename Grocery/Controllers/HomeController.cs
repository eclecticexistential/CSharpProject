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
        public ActionResult Plant(string Item)
        {
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                var entry = GroceryItemRepo.GetItem(id);
                _shoppingCart.AddItems(entry);
                return View("ShoppingCart", _shoppingCart);
            }
            else
            {
                return View();
            }
        }


        public ActionResult Meat()
        {
            ViewBag.Message = "Animal Protein to Refuel";
            var dasMeats = _groceryItemRepo.GetItems();
            return View(dasMeats);
        }

        [HttpPost]
        public ActionResult Meat(string Item)
        {
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                var entry = GroceryItemRepo.GetItem(id);
                _shoppingCart.AddItems(entry);
                return View("ShoppingCart", _shoppingCart);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Baking()
        {
            ViewBag.Message = "Items You Need to Bake, Season, and Create Deliciousness";
            var dasBake = _groceryItemRepo.GetItems();
            return View(dasBake);
        }

        [HttpPost]
        public ActionResult Baking(string Item)
        {
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                var entry = GroceryItemRepo.GetItem(id);
                _shoppingCart.AddItems(entry);
                return View("ShoppingCart",_shoppingCart.ShowItems());
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
            if (_shoppingCart == null)
            {
                _shoppingCart = new ShoppingCart();
            }
            if (ModelState.IsValid)
            {
                var entry = GroceryItemRepo.GetItem(id);
                _shoppingCart.AddItems(entry);
                return View("ShoppingCart", _shoppingCart);
            }
            else
            {
                return View();
            }
        }

        public ActionResult ShoppingCart(ShoppingCart _shoppingCart)
        {
            ViewBag.Message = "Items in Your Shopping Cart";
            var items = _shoppingCart.ShowItems();
            int totalPrice = items.Sum(e => e.Price);
            ViewBag.TotalPrice = totalPrice;
            return View(items);
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