using AutoMapper;
using Khuari.DTO;
using Khuari.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Khuari.Controllers.API
{
    public class CustomersController : ApiController
    {
       

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //Get//API/customers
        public IEnumerable<CustomerDTO> GetCustomers(string CName= null)
        {
            var Query = _context.Customers.Include(x => x.MembershipType);
            if (!string.IsNullOrEmpty(CName))
            {
              return Query.Where(x=>x.C_Name.Contains(CName)).ToList().Select(Mapper.Map<Customer, CustomerDTO>);
            }
            else
            {
                return Query.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
            }

                
                
                
                
                
               
        }
        //Get//API/customers/id
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.C_Id == id);

            if (customer== null)
            {
                NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer)) ;
        }

        //Post//API/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerdto)
        {
            if (!ModelState.IsValid)
            {
               return BadRequest();
            }
            else
            {
                var customer = Mapper.Map<CustomerDTO, Customer>(customerdto);

                _context.Customers.Add(customer);
                _context.SaveChanges();
                customerdto.C_Id = customer.C_Id;
            }
            return Created(new Uri(Request.RequestUri+"/"+ customerdto.C_Id),customerdto);
        }
        //Put//API/customers/1
        [HttpPut]
        public void UpdateCustomer (int id, CustomerDTO customerdto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDB = _context.Customers.SingleOrDefault(x => x.C_Id == id);

            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                Mapper.Map<CustomerDTO,Customer>(customerdto, customerInDB);

               
                _context.SaveChanges();
            }


        }
        //Delete//API/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
     
            var customerInDB = _context.Customers.SingleOrDefault(x => x.C_Id == id);

            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Customers.Remove(customerInDB);
                _context.SaveChanges();
            }
        }



    }
}
