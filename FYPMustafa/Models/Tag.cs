using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYPMustafa.Models
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }
        public string ItemID { get; set; }
        public string TagName { get; set; }
    }
}