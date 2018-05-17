using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using video_rentals.Models;

namespace video_rentals.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }



        // [Min18YearsIfAmember]
        public DateTime? Birthday { get; set; }
        public bool IsSubscribedToNewsLet { get; set; }
        
        public byte MembershipTypeId { get; set; }

        public MemberShipTypeDto MemberShipType { get; set; }



    }
}