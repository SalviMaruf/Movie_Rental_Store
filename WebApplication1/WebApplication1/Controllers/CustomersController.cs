using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
     [Authorize]
    public class CustomersController:Controller
    {
        
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {

            _context.Dispose();
       }

        public ActionResult New()
        {
            var membershipType = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipType,
                
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                     MembershipTypes = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
              _context.Customers.Add(customer);

            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Birthdate = customer.Birthdate ;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter ;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.Name = customer.Name ;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)  //html.actionlink() method sends the id of the customer as the prameter of the action method
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel(customer)
            {
                
                MembershipTypes = _context.MembershipType
            };

            return View("CustomerForm", viewModel);
        }
       
        public ActionResult Index()
        {
           // var customers = _context.Customers.Include(c=>c.MembershipType).ToList();

            return View();
        }
        
        public ActionResult Details(int? id)
        {
           
            var customer = _context.Customers.Include(c=>c.MembershipType).FirstOrDefault(s => s.Id == id);
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