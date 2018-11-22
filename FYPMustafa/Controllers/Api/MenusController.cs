using FYPMustafa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FYPMustafa.Controllers.Api
{
    public class MenusController : ApiController
    {
        private ApplicationDbContext _context;

        public MenusController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IEnumerable<Menu> GetMenus(int id)
        {
            return _context.Menus.Where(c => c.RestaurantID == id).ToList();
        }
    }
}
