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

        [Authorize]
        public ActionResult Orders()
        {
            var uid = User.Identity.GetUserId();
            var restaurant = _context.Restaurants.SingleOrDefault(c => c.UserId == uid);
            if (restaurant == null)
                return View();
            return View(_context.Orders.ToList());
        }

        [Authorize]
        public ActionResult OrderHistory()
        {
            var uid = User.Identity.GetUserId();
            var restaurant = _context.Restaurants.SingleOrDefault(c => c.UserId == uid);
            if (restaurant == null)
                return View();
            return View(_context.OrderHistories.ToList());
        }

        [HttpPost]
        [Authorize]
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


        public ActionResult Serve(int id)
        {
            Order order = _context.Orders.Find(id);
            OrderHistory history = new OrderHistory
            {
                ItemName = order.ItemName,
                Quantity = order.Quantity,
                Date = order.Date,
                SpecialRequirments = order.SpecialRequirments,
                RestaurantID = order.RestaurantID
            };
            _context.OrderHistories.Add(history);
            _context.SaveChanges();

            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("Orders");
        }


        public ActionResult Cancel(int id)
        {
            Order order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("Orders");
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