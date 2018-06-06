using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab26.Models;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        [Authorize]
        public ActionResult ItemList()
        {
            CoffeeShopEntities db = new CoffeeShopEntities();

            List<Item> items = db.Items.ToList();

            ViewBag.Items = items;


            return View();
        }

        public ActionResult ItemListByDescription(string description)
        {
            CoffeeShopEntities db = new CoffeeShopEntities();

            List<Item> items = (from i in db.Items
                                where i.Description.Contains(description)
                                select i).ToList();
            ViewBag.Items = items;


            return View("ItemList");
        }

        public ActionResult ItemListSorted(string column)
        {
            CoffeeShopEntities db = new CoffeeShopEntities();

            if (column == "ID")
            {
                ViewBag.Items = (from i in db.Items
                                 orderby i.ID
                                 select i).ToList();
            }
            else if (column == "Name")
            {
                ViewBag.Items = (from i in db.Items
                                 orderby i.Name
                                 select i).ToList();
            }
            else if (column == "Description")
            {
                ViewBag.Items = (from i in db.Items
                                 orderby i.Description
                                 select i).ToList();
            }
            else if (column == "Quantity")
            {
                ViewBag.Items = (from i in db.Items
                                 orderby i.Quantity
                                 select i).ToList();
            }
            else if (column == "Price")
            {
                ViewBag.Items = (from i in db.Items
                                 orderby i.Price
                                 select i).ToList();
            }


            return View("ItemList");
        }

        [Authorize]
        public ActionResult Add(int id)
        {
            CoffeeShopEntities db = new CoffeeShopEntities();

            if (Session["Cart"] == null)
            {
                List<Item> cart = new List<Item>();

                cart.Add((from i in db.Items
                          where i.ID == id
                          select i).Single());

                Session.Add("Cart", cart);
            }
            else
            {
                List<Item> cart = (List<Item>)(Session["Cart"]);

                cart.Add((from i in db.Items
                          where i.ID == id
                          select i).Single());
            }

            return View();
        }
    }
}