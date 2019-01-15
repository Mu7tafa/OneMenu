using FYPMustafa.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPMustafa.Controllers
{
    public class RestaurantController : Controller
    {
        private ApplicationDbContext _context;

        public RestaurantController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Restaurant
        [Authorize]
        public ActionResult Index()
        {

            var uid = User.Identity.GetUserId();
            var restaurant = _context.Restaurants.SingleOrDefault(c => c.UserId == uid);
            if (restaurant == null)
                return View();
            return View(restaurant);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Restaurant restaurant)
        {
            var uid = User.Identity.GetUserId();
            var rInDb = _context.Restaurants.SingleOrDefault(c => c.UserId == uid);
            restaurant.UserId = uid;
            if (rInDb == null)
                _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "Home");
        }
        
        [Authorize]
        public ActionResult QRcode()
        {
            var uid = User.Identity.GetUserId();
            var restaurant = _context.Restaurants.SingleOrDefault(c => c.UserId == uid);
            if (restaurant == null)
                return View();

            ViewBag.Message = "http://onemenufyp.azurewebsites.net/CustomerMenu/Menus/" + restaurant.RestaurantID;

            return View();
        }
    }
}