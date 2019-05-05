using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<MovieGenre> MovieGenre { get; set; }
        public Movie Movie { get; set; }
    }
}