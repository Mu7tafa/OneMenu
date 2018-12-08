using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FYPMustafa.Models
{
    public class Menu
    {
        public Menu()
        {
            this.MenuItems = new HashSet<MenuItem>();
        }
        [Key]
        public int MenuID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Type { get; set; }
        
        [StringLength(250)]
        public string ImagePath { get; set; }

        public int RestaurantID { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}