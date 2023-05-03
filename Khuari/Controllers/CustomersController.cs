using Khuari.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Khuari.ViewModels;
using System.Data.Entity.Validation;

namespace Khuari.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(x => x.MembershipType).ToList();

            return View(customers);

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(x => x.C_Id == id);

            if (customer == null)
            
                return HttpNotFound();



            var viewModel = new NewCustomerViewModel
            {
                customer = customer,
                MembershipType = _context.MembershipTypes.ToList()


            };

                return View("New", viewModel);
    }

        
        public ActionResult New()
       {
            var mmbrhiptypes = _context.MembershipTypes.ToList();

            var ViewModel = new NewCustomerViewModel
            {
                
                MembershipType = mmbrhiptypes
            };


            return View(ViewModel);
        }

        #region saving form data

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Exclude = "C_Id")] NewCustomerViewModel cus)
        {
            var customer = cus.customer;

            ModelState.Remove(customer.C_Id.ToString());
            if (!ModelState.IsValid) // && customer.C_Id != 0
            {
                
                var mmbrhiptypes = _context.MembershipTypes.ToList();

                var ViewModel = new NewCustomerViewModel
                {
                    customer = customer,
                    MembershipType = mmbrhiptypes
                };


                return View("New", ViewModel);
            }
            else
            {
                if (customer.C_Id == null)
                {
                    //byte idindb = _context.Customers.OrderByDescending(x => x.C_Id).Select(x => x.C_Id).FirstOrDefault();
                    //customer.C_Id = Convert.ToByte(0);
                    _context.Customers.Add(customer);
                }
                else
                {
                    var CusInDB = _context.Customers.Single(x => x.C_Id == customer.C_Id);
                    CusInDB.C_Name = customer.C_Name;
                    CusInDB.DOB = customer.DOB;
                    CusInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                    CusInDB.MembershipTypeId = customer.MembershipTypeId;
                }


                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                
                return RedirectToAction("Index", "Customers");
            }





        }




        #endregion




    }
}