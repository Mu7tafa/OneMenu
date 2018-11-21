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
        [Key]
        public string MenuID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Type { get; set; }

        public string RestaurantID { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}