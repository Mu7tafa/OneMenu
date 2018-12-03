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
        public ActionResult Index()
        {
            if(!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            var uid = User.Identity.GetUserId();
            var restaurant = _context.Restaurants.SingleOrDefault(c => c.UserId == uid);
            if(restaurant == null)
                return View();
            return View(restaurant);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Restaurant restaurant)
        {
            restaurant.UserId = User.Identity.GetUserId();
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return RedirectToAction("Index", "Restaurant");
        }
    }
}