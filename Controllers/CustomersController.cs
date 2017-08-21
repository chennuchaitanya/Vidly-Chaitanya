using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        //public ActionResult Index()
        //{
        //var customers = new List<Customer> 
        //{
        //    new Customer{Name="Ellen Degeneres"},
        //    new Customer{Name="Oprah Winfrey"}

        //};
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
           // var viewModel = new RandomMovieViewModel { Customers = _context.Customers.Include(c=>c.MemberShipType).ToList() };
           //return View(viewModel);
            return View();
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MemberShipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MemberShipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customers=new Customer(),
                MemberShipTypes=membershipTypes
            };

            return View("CustomerForm",viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customers)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customers=customers,
                    MemberShipTypes=_context.MemberShipType.ToList()
                };
                return View("CustomerForm",viewModel);
            }
            if (customers.Id == 0)
            {
                _context.Customers.Add(customers);
            }
            else
            {
                var customerInDb = _context.Customers.Single(m => m.Id == customers.Id);
                customerInDb.Name = customers.Name;
                customerInDb.BirthDate = customers.BirthDate;
                customerInDb.MemberShipTypeId = customers.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customers.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer==null)
                return HttpNotFound();
            else
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customers = customer,
                    MemberShipTypes=_context.MemberShipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            
        }
    }

}