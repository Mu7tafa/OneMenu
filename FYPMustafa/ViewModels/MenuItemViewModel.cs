using FYPMustafa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPMustafa.ViewModels
{
    public class MenuItemViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Menu> Menus { get; set; }

        public MenuItem MenuItems { get; set; }
        public String tags { get; set; }

        public FileModel Files { get; set; }

    }
}