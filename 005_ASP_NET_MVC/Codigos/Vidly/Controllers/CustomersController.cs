using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db;

        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose(); // Limpia dbContext de la memoria.
        }

        public ActionResult Index()
        {
           return View();
        }

        [Route("Customers/Details/{id}")]
        public ActionResult CustomerDetails(int id)
        {
            var customer = db.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        [Route("Customers/Edit/{id}")]
        public ActionResult EditCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id.Equals(id));
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = db.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [Route("Customers/Add")]
        public ActionResult AddCustomer()
        {
            var membershipTypes = db.MembershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                // Regresa un formulario con los datos para ser correctamente modificados.
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = db.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id <= 0) // Sin Id asignado agregar customer.
            {
                db.Customers.Add(customer);
            }
            else // Con Id asignado actualizar customer.
            {
                var updated_customer = db.Customers.FirstOrDefault(c => c.Id.Equals(customer.Id));
                updated_customer.Name = customer.Name;
                updated_customer.Birthdate = customer.Birthdate;
                updated_customer.MembershipTypeId = customer.MembershipTypeId;
                updated_customer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                //TryUpdateModel(updated_customer, "", new string[] { "Name", "MembershipTypeId", "IsSubscribedToNewsletter" });
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }

}