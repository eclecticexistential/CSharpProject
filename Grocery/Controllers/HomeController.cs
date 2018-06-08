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
        private static GroceryItemRepo _groceryItemRepo = null;
        private static ShoppingCart _shoppingCart = null;

        static HomeController()
        {
            _groceryItemRepo = new GroceryItemRepo();
            _shoppingCart = new ShoppingCart();
        }

        public HomeController()
        {
            ViewBag._shoppingCart = _shoppingCart;
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
                _shoppingCart.AddItems(id);
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
            var dasMeats = _groceryItemRepo.GetItems();
            return View(dasMeats);
        }

        [HttpPost]
        public ActionResult Meat(string Item)
        {
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                _shoppingCart.AddItems(id);
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
            var dasBake = _groceryItemRepo.GetItems();
            return View(dasBake);
        }

        [HttpPost]
        public ActionResult Baking(string Item)
        {
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                _shoppingCart.AddItems(id);
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
                _shoppingCart.AddItems(id);
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
            return View(_shoppingCart);
        }

        [HttpPost]
        public void DeleteItem(string Item)
        {
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                _shoppingCart.RemoveCartItem(id);
                RedirectToAction("ShoppingCart");
            }
        }

        [HttpPost]
        public ActionResult AddItem(string Item)
        {
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                _shoppingCart.AddItems(id);
            }
            return RedirectToAction("ShoppingCart");
        }

        [HttpPost]
        public ActionResult DeductItem(string Item)
        {
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                _shoppingCart.DeductItem(id);
            }
            return RedirectToAction("ShoppingCart");
        }
    }
}