using Grocery.Data;
using Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(int id)
        {
            try
            {
                _shoppingCart.ChangeShoppingCartItemAmount(id, true);
            }
            catch
            {
                var entry = GroceryItemRepo.GetItems(id);
                _shoppingCart.ItemsInCart.Add(entry);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, bool math)
        {
            _shoppingCart.ChangeShoppingCartItemAmount(id, math);
            return View("ShoppingCart");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _shoppingCart.RemoveCartItem(id);
            return View("ShoppingCart");
        }

        public ActionResult Plant()
        {
            ViewBag.Message = "Food You Need to Feel Healthy and Live Well";
            var dasPlants = _groceryItemRepo.GetItems();
            return View(dasPlants);
        }

        public ActionResult Meat()
        {
            ViewBag.Message = "Animal Protein to Refuel";
            var dasMeats = _groceryItemRepo.GetItems();
            return View(dasMeats);
        }
        public ActionResult Baking()
        {
            ViewBag.Message = "Items You Need to Bake, Season, and Create Deliciousness";
            var dasBake = _groceryItemRepo.GetItems();
            return View(dasBake);
        }
        public ActionResult Recipes()
        {
            ViewBag.Message = "Meal Ideas to Spice Things Up";

            return View();
        }
        public ActionResult ShoppingCart()
        {
            if(_shoppingCart != null)
            {
                ViewBag.Message = "Items in Your Shopping Cart";
                var dasCart = _shoppingCart.GetCartItems();
                return View(dasCart);
            }
            return View();
        }
    }
}