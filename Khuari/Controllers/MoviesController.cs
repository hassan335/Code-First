using Khuari.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Khuari.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var Movies = _context.Movies.Include(x => x.Genre).ToList();
            return View(Movies);

         }

        public ActionResult Details(int id)
        {
            var customer = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.M_Id == id);

            if (customer == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(customer);
            }

        }






    }
}