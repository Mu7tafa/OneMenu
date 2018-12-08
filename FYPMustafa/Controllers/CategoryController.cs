using FYPMustafa.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPMustafa.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _context;
        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Save(Category category)
        {
            var uid = User.Identity.GetUserId();
            var restaurant = _context.Restaurants.SingleOrDefault(c => c.UserId == uid);
            if (restaurant == null)
                return RedirectToAction("Index", "Restaurant");

            category.RestaurantID = restaurant.RestaurantID;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Create", "Category");
        }
    }
}