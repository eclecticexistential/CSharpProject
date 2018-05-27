using Grocery.Data;
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

        public ActionResult Plant()
        {
            ViewBag.Message = "Food You Need to Feel Healthy and Live Well";

            return View();
        }

        public ActionResult Meat()
        {
            ViewBag.Message = "Animal Protein to Refuel";
            var dasMeats = _groceryItemRepo.GetMeats();
            return View(dasMeats);
        }
        public ActionResult Baking()
        {
            ViewBag.Message = "Items You Need to Bake, Season, and Create Deliciousness";

            return View();
        }
        public ActionResult Recipes()
        {
            ViewBag.Message = "Meal Ideas to Spice Things Up";

            return View();
        }
    }
}