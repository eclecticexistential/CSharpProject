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

        public HomeController()
        {
            _groceryItemRepo = new GroceryItemRepo();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Add()
        {
            var entry = new Entry()
            {
                ID = Items.Id
            };
            return View(); // may not need
        }

        [HttpPost]
        public ActionResult Add(int id)
        {
            public Entry entry = Items.GetItems((int)id);
            ShoppingCart.AddEntry(entry);
            return RedirectToAction(whateverthecurrentpageis);
        }
        

        [HttpPost]
        public ActionResult Edit(Entry entry)
        {
        // add or subtract amount of goods
        // if zero remove?
        Items item = GetItems(entry.Id);
            // +1 if adding
            // -1 is removing
        return RedirectToAction(whateverthecurrentpageis);
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
    }
}