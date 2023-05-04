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
    public class CustomersController : ApiController
    {
       

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //Get//API/customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
          return  _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }
        //Get//API/customers/id
        public CustomerDTO GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.C_Id == id);

            if (customer== null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Customer,CustomerDTO>(customer);
        }

        //Post//API/customers
        [HttpPost]
        public CustomerDTO CreateCustomer(CustomerDTO customerdto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customer = Mapper.Map<CustomerDTO, Customer>(customerdto);

                _context.Customers.Add(customer);
                _context.SaveChanges();
                customerdto.C_Id = customer.C_Id;
            }
            return customerdto;
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
            int idt;
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
