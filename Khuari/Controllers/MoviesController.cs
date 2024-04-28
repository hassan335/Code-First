using Khuari.Models;
using Khuari.ViewModels;
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
            if (User.IsInRole(Roles.CanManageMovies))
          
                return View("List");
            
                return View("ReadOnlyList");



            //var Movies = _context.Movies.Include(x => x.Genre).ToList();
            //return View(Movies);

        }

        public ActionResult Edit(int id)
        {
            


            var movie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.M_Id == id);

            if (movie == null)
            {

                return HttpNotFound();
            }
            

            var viewModel = new NewMoviesViewModel
            {
                movie = movie,
                Gener = _context.Generes.ToList()


            };

            return View("New", viewModel);





        }
        [Authorize(Roles = Roles.CanManageMovies)]
        public ActionResult New()
        {
            var gener = _context.Generes.ToList();

            var ViewModel = new NewMoviesViewModel
            {
                movie = new Movie(),
                Gener = gener
            };


            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( NewMoviesViewModel mo) //[Bind(Exclude = "C_Id")]
        {
            var mov = mo.movie;

            //ModelState.Remove(customer.C_Id.ToString());
            if (!ModelState.IsValid) // && customer.C_Id != 0
            {

                var GenList = _context.Generes.ToList();

                var ViewModel = new NewMoviesViewModel
                {
                    movie = mov,
                    Gener = GenList
                };


                return View("New", ViewModel);
            }
            else
            {
                if (mov.M_Id == null)
                {
                    //byte idindb = _context.Customers.OrderByDescending(x => x.C_Id).Select(x => x.C_Id).FirstOrDefault();
                    //customer.C_Id = Convert.ToByte(0);
                    _context.Movies.Add(mov);
                }
                else
                {
                    var MovInDB = _context.Movies.Single(x => x.M_Id == mov.M_Id);
                    MovInDB.M_Name = mov.M_Name;
                    MovInDB.ReleaseDate = mov.ReleaseDate;
                    MovInDB.NumberInStockk = mov.NumberInStockk;
                    MovInDB.G_Id = mov.G_Id;
                    MovInDB.DateAdded = DateTime.Now;
                }


                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }


                return RedirectToAction("Index", "Movies");
            }





        }






    }
}