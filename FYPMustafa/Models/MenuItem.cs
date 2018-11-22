using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FYPMustafa.Models
{
    public class MenuItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuItem()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
        }

        [Key]
        public int ItemID { get; set; }

        public string MenuID { get; set; }

        public string CategoryID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Status { get; set; }

        public Nullable<decimal> Price { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public ICollection<Picture> Pictures { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}