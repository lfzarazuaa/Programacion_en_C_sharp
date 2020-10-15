using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
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
            _context.Dispose(); // Limpia dbContext de la memoria.
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            if (customers.Count == 0)
                return View();
            return View(customers);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult CustomerDetails(int id)
        {

            var customers = _context.Customers;
            var customer = customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            if (customer==null)
                return HttpNotFound();
            return View(customer);
        }


    }

}