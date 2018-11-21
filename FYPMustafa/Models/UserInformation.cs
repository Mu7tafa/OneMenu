using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYPMustafa.Models
{
    public class UserInformation
    {
        [Key]
        public string UserID { get; set; }
        public string RestuarantID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}