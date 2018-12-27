using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FYPMustafa.Models
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }

        public int ItemID { get; set; }

        public string TagName { get; set; }

        [ForeignKey("ItemID")]
        public virtual MenuItem MenuItem { get; set; }
    }
}