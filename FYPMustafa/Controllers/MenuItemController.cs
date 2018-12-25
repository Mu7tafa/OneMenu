using FYPMustafa.Models;
using FYPMustafa.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPMustafa.Controllers
{
    public class MenuItemController : Controller
    {
        ApplicationDbContext _context;
        public MenuItemController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: MenuItem
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var uid = User.Identity.GetUserId();
            var restaurant = _context.Restaurants.SingleOrDefault(c => c.UserId == uid);
            if (restaurant == null)
                return RedirectToAction("Index", "Restaurant");

            var menus = _context.Menus.Where(c => c.RestaurantID == restaurant.RestaurantID).ToList();
            var categories = _context.Categories.Where(c => c.RestaurantID == restaurant.RestaurantID).ToList();

            var viewModel = new MenuItemViewModel
            {
                MenuItems = new MenuItem(),
                Categories = categories,
                Menus = menus
            };
            viewModel.tags = "fsdf, fsdkfjd, fsd";

            return View(viewModel);
        }
        public ActionResult Save(MenuItemViewModel menuItemViewModel)
        {
            return View("Create", menuItemViewModel);
        }
    }
}