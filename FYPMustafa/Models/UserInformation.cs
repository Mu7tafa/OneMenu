using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FYPMustafa.Models
{
    public class UserInformation
    {
        [Key]
        public string UserID { get; set; }
        public string RestuarantID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "char")]
        [StringLength(10)]
        public string Gender { get; set; }

        [Column(TypeName = "char")]
        [StringLength(10)]
        public string Role { get; set; }

        public Nullable<System.DateTime> DateOfBirth { get; set; }

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

        [Column(TypeName = "char")]
        [StringLength(20)]
        public string Status { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Phone { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}