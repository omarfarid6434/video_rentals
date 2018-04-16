using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using video_rentals.Models;
namespace video_rentals.ViewModels
{
    public class CustomerFormViewModels
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}