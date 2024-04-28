using AutoMapper;
using Khuari.DTO;
using Khuari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

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
        public IEnumerable<MovieDTO> GetMovies(string mName = null)
          
       {
            if (!String.IsNullOrEmpty(mName))
            {
                return _context.Movies.Include(y => y.Genre).Where(x=> x.M_Name.Contains(mName) && x.NumberAvaliable > 0 ).ToList().Select(Mapper.Map<Movie, MovieDTO>);
            }
           

            return _context.Movies.Include(y=>y.Genre).ToList().Select(Mapper.Map<Movie, MovieDTO>);
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

        //Delete//API/customers/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {

            var movieInDB = _context.Movies.SingleOrDefault(x => x.M_Id == id);

            if (movieInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Movies.Remove(movieInDB);
                _context.SaveChanges();
            }
        }





    }
}
