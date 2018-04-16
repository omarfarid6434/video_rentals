using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using video_rentals.Models;


namespace video_rentals.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }


        [Display(Name="Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Display(Name="Realase Date")]
        public DateTime RealaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        

        [Display(Name="Number In Stock")]
        [Range(1,20)]
        public byte NumberInStock { get; set; }
    }
}