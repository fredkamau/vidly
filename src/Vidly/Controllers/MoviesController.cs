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
            List<Customer> mteja = new List<Customer>
            {
                new Customer{ Id = 1, Name="fredrick" },
                new Customer{ Id = 2, Name="wagathegi" },
                new Customer{ Id = 1, Name="kamau" }
            };
            RandomMovieViewModel rm = new RandomMovieViewModel
            {
                //initialise movie property
                movie = cinema,
                customer = 
            };
            return View(rm);
            
        }
         

    }
}