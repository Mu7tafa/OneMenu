using FYPMustafa.Models;
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
            //Change the id to the logged in user
            var restaurant = _context.Restaurants.SingleOrDefault(c => c.UserId == "1");
            if(restaurant == null)
                return View();
            return View(restaurant);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return RedirectToAction("Index", "Restaurant");
        }
    }
}