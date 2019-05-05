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
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //DbContext is a Dispsable object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var movies = _context.Movie;
            return View(movies);
        }
        public ActionResult MovieForm()
        {
            var movieGenres = _context.MovieGenres.ToList();
            MovieFormViewModel movieFormViewModel = new MovieFormViewModel { MovieGenre = movieGenres };
            return View(movieFormViewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movie.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movie.Single(c => c.Id == movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.GenreId = movie.GenreId;
                MovieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel { Movie = movie, MovieGenre = _context.MovieGenres.ToList() };
            return View("MovieForm", viewModel);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
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