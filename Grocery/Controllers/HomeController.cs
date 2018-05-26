using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocery.Controllers
{
    public class HomeController : Controller
    {
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

            return View();
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