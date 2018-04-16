using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace video_rentals.Models
{
    public class MemberShipType
    {
       
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }


        public static readonly byte Unkown = 0;
        public static readonly byte PayASYouGo = 1;
             

    }
}