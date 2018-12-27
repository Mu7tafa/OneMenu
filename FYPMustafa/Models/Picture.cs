using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FYPMustafa.Models
{
    public class Picture
    {
        [Key]
        public int PictureID { get; set; }

        public int ItemID { get; set; }
        public string PictureLocation { get; set; }
        public string Extension { get; set; }

        [ForeignKey("ItemID")]
        public virtual MenuItem MenuItem { get; set; }
    }
}