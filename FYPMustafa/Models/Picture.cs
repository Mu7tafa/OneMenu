﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYPMustafa.Models
{
    public class Picture
    {
        [Key]
        public int PictureID { get; set; }
        public string ItemID { get; set; }
        public string PictureLocation { get; set; }
        public string Extension { get; set; }
    }
}