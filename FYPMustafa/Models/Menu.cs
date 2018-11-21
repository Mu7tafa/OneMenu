using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYPMustafa.Models
{
    public class Menu
    {
        [Key]
        public string MenuID { get; set; }
        public string Type { get; set; }
        public string RestaurantID { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}