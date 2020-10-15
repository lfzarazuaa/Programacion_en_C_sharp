using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customersData = GetCustomers();
            var customers = new List<Customer>();
            customers = customersData.ToList();
            if (customers.Count == 0)
            {
                return View();
            }
            else
            {
                return View(customers);
            }
        }

        
        [Route("Customers/Details/{id}")]
        public ActionResult CustomerDetails(int id)
        {
            if (id<25)
            {
                var customers = GetCustomers();
                var customer = customers.FirstOrDefault(c => c.Id == id);
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        private static IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer { Id = 1, Name = "Miranda" },
                new Customer { Id = 2, Name = "Merritt" },
                new Customer { Id = 3, Name = "Tad" },
                new Customer { Id = 4, Name = "Galvin" },
                new Customer { Id = 5, Name = "Allen" },
                new Customer { Id = 6, Name = "Rudyard" },
                new Customer { Id = 7, Name = "Wade" },
                new Customer { Id = 8, Name = "Moana" },
                new Customer { Id = 9, Name = "Eugenia" },
                new Customer { Id = 10, Name = "Graham" },
                new Customer { Id = 11, Name = "Rigel" },
                new Customer { Id = 12, Name = "Aurora" },
                new Customer { Id = 13, Name = "Fitzgerald" },
                new Customer { Id = 14, Name = "Amber" },
                new Customer { Id = 15, Name = "Chaim" },
                new Customer { Id = 16, Name = "Audrey" },
                new Customer { Id = 17, Name = "Hammett" },
                new Customer { Id = 18, Name = "Shad" },
                new Customer { Id = 19, Name = "Melanie" },
                new Customer { Id = 20, Name = "Kibo" },
                new Customer { Id = 21, Name = "Aquila" },
                new Customer { Id = 22, Name = "Diana" },
                new Customer { Id = 23, Name = "Stone" },
                new Customer { Id = 24, Name = "Whitney" },
                new Customer { Id = 25, Name = "Vladimir" }
            };
        }

    }
}