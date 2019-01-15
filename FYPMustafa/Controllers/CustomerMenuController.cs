using FYPMustafa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPMustafa.Controllers
{
    public class CustomerMenuController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerMenuController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: CustomerMenu
        public ActionResult Menus(int id)
        {
            Session["rID"] = id;
            return View(_context.Menus.Where(c => c.RestaurantID == id).ToList());
        }
        public ActionResult Order(int id)
        {
            var item = _context.MenuItems.Single(c => c.ItemID == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = item.Name;
            Order order = new Order();
            order.ItemName = item.Name;
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Save(Order order)
        {
            order.RestaurantID = (int) Session["rID"];
            order.Date = DateTime.Today.ToString();
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Menus/" + (int)Session["rID"]);
        }
        public ActionResult MenuItems(int id)
        {
            return View(_context.MenuItems.Where(c => c.MenuID == id).ToList());
        }
        public ActionResult ItemDetail(int id)
        {
            return View(_context.MenuItems.Include("Pictures").SingleOrDefault(c => c.ItemID == id));
        }
    }
}