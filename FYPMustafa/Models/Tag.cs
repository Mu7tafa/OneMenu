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
        public string TagID { get; set; }
        public string ItemID { get; set; }
        public string Tag1 { get; set; }

        public virtual MenuItem MenuItem { get; set; }
    }
}