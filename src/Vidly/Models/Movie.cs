using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }      
        public byte GenreId { get; set; }
        //navigation property-allows us to navigate from movie to Genre 
        public MovieGenre Genre { get; set; }
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }
    }
}