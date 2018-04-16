using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using video_rentals.Models;

namespace video_rentals.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customer { get; set; }
    }
}