using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;


namespace Vidly.Controllers.Apis
{
    public class CustomersController : ApiController
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

        //GET /api/Customers
        public IHttpActionResult GetCustomers()
        {
            var customer = _context.Customers.Include(m=>m.MemberShipType).ToList();
            return Ok(customer);

        }
        //GET /api/Customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.Id == id);
            if(customer==null)
                throw  new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        //POST /api/Customers
        [HttpPost]
        public Customer CreateCustomer(Customer customers)
        {
            if(!ModelState.IsValid)
            {
                
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Customers.Add(customers);
            _context.SaveChanges();
            return customers;

        }

        //PUT /api/Customers
        [HttpPut]
        public void UpdateCustomer(int id, Customer customers)
        {
            var customerinDb = _context.Customers.SingleOrDefault(m => m.Id == id);
            if (customerinDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            customerinDb.Name = customers.Name;
            customerinDb.BirthDate = customers.BirthDate;
            customerinDb.IsSubscribedToNewsLetter = customers.IsSubscribedToNewsLetter;
            customerinDb.MemberShipTypeId = customers.MemberShipTypeId;

            _context.SaveChanges();


        }

        //DELETE /api/Customers
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerinDb = _context.Customers.SingleOrDefault(m => m.Id == id);

            if (customerinDb == null)
                return NotFound();

            _context.Customers.Remove(customerinDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
