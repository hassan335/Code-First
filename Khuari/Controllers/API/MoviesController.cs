using AutoMapper;
using Khuari.DTO;
using Khuari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Khuari.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //Get//API/Moviess
        public IEnumerable<MovieDTO> GetMovies()
          
        {
            
                return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
        }

        //Get//API/Movies/id
        public IHttpActionResult GetMovies(int id)
        {
            var Movies = _context.Movies.SingleOrDefault(x => x.M_Id == id);

            if (Movies == null)
            {
                NotFound();
            }
            return Ok(Mapper.Map< Movie, MovieDTO>(Movies));
        }


        //Post//API/customers
        [HttpPost]
        public IHttpActionResult CreateMOvie(MovieDTO moviedto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var movie = Mapper.Map<MovieDTO, Movie>(moviedto);

                _context.Movies.Add(movie);
                _context.SaveChanges();
                moviedto.M_Id = movie.M_Id;
            }
            return Created(new Uri(Request.RequestUri + "/" + moviedto.M_Id), moviedto);
        }


        //Put//API/movies/1
        [HttpPut]
        public void UpdateMovies(int id, MovieDTO moviedto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieInDB = _context.Movies.SingleOrDefault(x => x.M_Id == id);

            if (movieInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                Mapper.Map<MovieDTO,Movie>(moviedto, movieInDB);


                _context.SaveChanges();
            }


        }





    }
}
