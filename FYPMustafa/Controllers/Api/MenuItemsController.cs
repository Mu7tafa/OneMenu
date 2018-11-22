using FYPMustafa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace FYPMustafa.Controllers.Api
{
    public class MenuItemsController : ApiController
    {
        private ApplicationDbContext _context;

        public MenuItemsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            return _context.MenuItems.Include(c => c.Tags).ToList();
        }
    }
}
