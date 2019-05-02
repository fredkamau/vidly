using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            Movie cinema = new Movie() {  Name = "The Inception"};
            Customer mteja = new Customer {Id = 1, Name="fredrick"};
            RandomMovieViewModel rm = new RandomMovieViewModel
            {
                //initialise movie property--mapping properties to objects
                movie = cinema,
                customer = mteja
            };
            return View(rm);
            
        }
         

    }
}