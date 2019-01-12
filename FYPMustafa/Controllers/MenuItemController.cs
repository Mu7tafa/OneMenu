using FYPMustafa.Models;
using FYPMustafa.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FYPMustafa.Controllers
{
    [Authorize]
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
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                var rID = new RestaurantHelper().GetRestaurant(User.Identity.GetUserId());
                if (rID == 0)
                    return RedirectToAction("Index", "Restaurant");
                var menus = _context.Database
                        .SqlQuery<MenuItem>("SELECT ItemID, Status, Price, Description, Ingredients, CategoryID, MenuItems.MenuID, MenuItems.Name FROM Menus, MenuItems where Menus.RestaurantID = "+ rID +" And Menus.MenuID = MenuItems.MenuID")
                        .ToList<MenuItem>();
                return View(menus); ;
            }
            return View(_context.MenuItems.Where(c => c.MenuID == id).ToList());
        }
        public ActionResult Create()
        {
            //Gets the restaurant ID of the current user
            var rID = new RestaurantHelper().GetRestaurant(User.Identity.GetUserId());
            if (rID == 0)
                return RedirectToAction("Index", "Restaurant");


            var menus = _context.Menus.Where(c => c.RestaurantID == rID).ToList();
            var categories = _context.Categories.Where(c => c.RestaurantID == rID).ToList();

            var viewModel = new MenuItemViewModel
            {
                Categories = categories,
                Menus = menus
            };
            viewModel.tags = "";

            return View(viewModel);
        }
        public ActionResult Save(MenuItemViewModel menuItemViewModel, IEnumerable<HttpPostedFileBase> files)
        {
            MenuItem menuItem = menuItemViewModel.MenuItems;
            menuItem.Pictures = SaveImages(files);
            menuItem.Tags = SaveTags(menuItemViewModel.tags);
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ICollection<Picture> SaveImages(IEnumerable<HttpPostedFileBase> files)
        {
            List<Picture> pictures = new List<Picture>();
            foreach (HttpPostedFileBase file in files)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(Guid.NewGuid().ToString());
                    pic += Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/Images/MenuItems/") + pic);
                    //Save file to server folder  
                    file.SaveAs(ServerSavePath);

                    Picture picture = new Picture();
                    picture.PictureLocation = pic;
                    picture.Extension = file.ContentType;
                    pictures.Add(picture);
                }
            }
            return pictures;
        }
        public ICollection<Tag> SaveTags(String tags)
        {
            List<Tag> Tags = new List<Tag>();
            List<string> strings = tags.Split(',').ToList<string>();
            foreach(string str in strings)
            {
                Tag tag = new Tag();
                tag.TagName = str;
                Tags.Add(tag);
            }
            return Tags;
        }
        public ActionResult Edit(int? id)
        {
            var rID = new RestaurantHelper().GetRestaurant(User.Identity.GetUserId());
            if (rID == 0)
                return RedirectToAction("Index", "Restaurant");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _context.Configuration.ProxyCreationEnabled = false;
            MenuItem menuitem = _context.MenuItems.Include(c => c.Tags).SingleOrDefault(c => c.ItemID == id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }

            var menus = _context.Menus.Where(c => c.RestaurantID == rID).ToList();
            var categories = _context.Categories.Where(c => c.RestaurantID == rID).ToList();

            var viewModel = new MenuItemViewModel
            {
                MenuItems = menuitem,
                Categories = categories,
                Menus = menus
            };
            viewModel.tags = "";
            foreach (Tag tagg in menuitem.Tags)
            {
                viewModel.tags = viewModel.tags + "," + tagg.TagName;
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuItemViewModel menuItem)
        {
            if (ModelState.IsValid)
            {
                _context.Tags.RemoveRange(_context.Tags.Where(x => x.ItemID == menuItem.MenuItems.ItemID));
                _context.SaveChanges();

                var menuItemDB = _context.MenuItems.Single(c => c.ItemID == menuItem.MenuItems.ItemID);
                menuItemDB.Name = menuItem.MenuItems.Name;
                menuItemDB.MenuID = menuItem.MenuItems.MenuID;
                menuItemDB.CategoryID = menuItem.MenuItems.CategoryID;
                menuItemDB.Price = menuItem.MenuItems.Price;
                menuItemDB.Ingredients = menuItem.MenuItems.Ingredients;
                menuItemDB.Tags = SaveTags(menuItem.tags);
                menuItemDB.Status = menuItem.MenuItems.Status;
                menuItemDB.Description = menuItem.MenuItems.Description;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuItem);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = _context.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuItem menuItem = _context.MenuItems.Find(id);
            _context.MenuItems.Remove(menuItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}