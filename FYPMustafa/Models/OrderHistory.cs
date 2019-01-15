using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYPMustafa.Models
{
    public class OrderHistory
    {
        [Key]
        public int OrderID { get; set; }
        public string Date { get; set; }
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public int RestaurantID { get; set; }

        [DataType(DataType.MultilineText)]
        public string SpecialRequirments { get; set; }
    }
}