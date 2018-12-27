using FYPMustafa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPMustafa
{
    public class RestaurantHelper
    {
        ApplicationDbContext _context;
        public RestaurantHelper()
        {
            _context = new ApplicationDbContext();
        }

        public int GetRestaurant(String uid)
        {
            var restaurant = _context.Restaurants.SingleOrDefault(c => c.UserId == uid);
            if (restaurant == null)
                return 0;
            return restaurant.RestaurantID;
        }
    }
}