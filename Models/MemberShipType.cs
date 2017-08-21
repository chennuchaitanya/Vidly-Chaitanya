﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte Discount  { get; set; }
    }
}