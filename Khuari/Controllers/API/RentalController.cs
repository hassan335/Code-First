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
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDTO rentaldto)
        {
            var Customer = _context.Customers.Single(c => c.C_Id == rentaldto.Customer_ID);

            var movies = _context.Movies.Where(m => rentaldto.MovieIds.Contains(m.M_Id));

            
            foreach (var item in movies)
            {
                if (item.NumberAvaliable ==0)
                {
                    return BadRequest("Movie Is not avaliable");
                }
                item.NumberAvaliable--;

                var rn = new Rental
                {
                    customer = Customer,
                    movie = item,
                    DateRented = DateTime.Now

                };

            _context.Rentals.Add(rn);
            }

            return Ok();

           
        }

      

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


    }
}
