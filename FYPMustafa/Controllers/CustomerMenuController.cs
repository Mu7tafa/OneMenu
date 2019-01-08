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
            return View(_context.Menus.Where(c => c.RestaurantID == id).ToList());
        }
        public ActionResult MenuItems(int id)
        {
            return View(_context.MenuItems.Where(c => c.MenuID == id).ToList());
        }
        public ActionResult ItemDetail(int id)
        {
            return View(_context.MenuItems.SingleOrDefault(c => c.ItemID == id));
        }
    }
}