using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public byte? MemberShipTypeId { get; set; }

        [Display(Name="Date of Birth")]
        [Min18IfaMember]
        public DateTime? BirthDate { get; set; }
    }
}