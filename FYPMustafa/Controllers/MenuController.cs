using FYPMustafa.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPMustafa.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private ApplicationDbContext _context;
        public MenuController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Menu
        public ActionResult Index()
        {
            var rID = new RestaurantHelper().GetRestaurant(User.Identity.GetUserId());
            if (rID == 0)
                return RedirectToAction("Index", "Restaurant");
            return View(_context.Menus.Where(c => c.RestaurantID == rID).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Save(Menu menu, HttpPostedFileBase file)
        {
            var rID = new RestaurantHelper().GetRestaurant(User.Identity.GetUserId());
            if (rID == 0)
                return RedirectToAction("Index", "Restaurant");
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(Guid.NewGuid().ToString());
                pic += file.FileName;
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Images/Menu"), pic);
                menu.ImagePath = pic;
                file.SaveAs(path);

            }

            menu.RestaurantID = rID;
            _context.Menus.Add(menu);
            _context.SaveChanges();
            return RedirectToAction("Index", "Restaurant");
        }

    }
}