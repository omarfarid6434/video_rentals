using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using video_rentals.Models;


namespace video_rentals.Models
{
    public class Customer
    {
       
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Birth of Date")]
        [Min18YearsIfAmember]
        public DateTime? Birthday { get; set; }
        public bool IsSubscribedToNewsLet { get; set; }

        [Display(Name ="Membership Type")]
        public MemberShipType MemberShipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}