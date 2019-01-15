using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYPMustafa.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string Date { get; set; }
        public string ItemName { get; set; }

    }
}