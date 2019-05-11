using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
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
        public IEnumerable<MovieDtos> GetMovies()
        {
            return _context.Movie.ToList().Select(Mapper.Map<Movie, MovieDtos>);
        }
        //GET /api/movies/1
        public MovieDtos GetMovie(int id)
        {
           var movie =  _context.Movie.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            }
            return Mapper.Map<Movie, MovieDtos>(movie);
        }
        //POST api/customers
        [HttpPost]
        public MovieDtos CreateMovie (MovieDtos movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var movie = Mapper.Map<MovieDtos, Movie>(movieDto);
                _context.Movie.Add(movie);
                _context.SaveChanges();
                movieDto.Id = movie.Id;
            }
            return movieDto;                       
        }
        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDtos movieDto)
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
            Mapper.Map<MovieDtos, Movie>(movieDto, movieInDb);          
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
