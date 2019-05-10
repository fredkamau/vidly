using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/movies
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movie.ToList();
        }
        //GET /api/movies/1
        public Movie GetMovie(int id)
        {
           var movie =  _context.Movie.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            }
            return movie;
        }
        //POST api/customers
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                _context.Movie.Add(movie);
                _context.SaveChanges();
            }
            return movie;                       
        }
        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, Movie movie)
        {   //When submitting the form, if you have an error in the date, ModelState.IsValid will be false 
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadGateway);
            }
            var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.GenreId = movie.GenreId;
            _context.SaveChanges();       
        }
        //DELETE /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movie.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
