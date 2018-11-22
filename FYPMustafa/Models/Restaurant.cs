using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FYPMustafa.Models
{
    public class Restaurant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurant()
        {
            this.Menus = new HashSet<Menu>();
        }

        [Key]
        public int RestaurantID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Street { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string City { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Country { get; set; }

        [Column(TypeName = "char")]
        [StringLength(10)]
        public string ZipCode { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Menu> Menus { get; set; }
        
    }
}