using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Models.IdentityModels;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
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

        // Verbo GET: /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = db.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query)) // Filtrado de customers por nombre.
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customersDto = customersQuery.ToList()
                .Select(Mapper.Map<Customer, CustomerDto>); // Pasa como delegado el método Map que recibe un objeto de tipo Customer como parámetro.
            return Ok(customersDto);
        }

        // Verbo GET: /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.FirstOrDefault(c => c.Id.Equals(id));

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer)); // Respuesta Código 200 y objeto.
        }

        // Verbo POST: /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest($"The arguments are invalid: {customerDto}");

            if (db.MembershipTypes.Any(m => m.Id == customerDto.MembershipTypeId))
                return BadRequest($"The memberShipType don't exist.");

            var customer = db.Customers.Add(Mapper.Map<CustomerDto, Customer>(customerDto));
            db.SaveChanges();

            customerDto.Id = customer.Id; // Asignar el Id dado desde la db.
            return Created(new Uri($"{Request.RequestUri}/{customerDto.Id}"), customerDto); // Crear recurso con estado 201 y pasar un objeto como respuesta.
        }

        // Verbo PUT: /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            var customerInDb = db.Customers.FirstOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest($"The arguments are invalid, needed: {customerDto}");

            if (db.MembershipTypes.Any(m => m.Id == customerDto.MembershipTypeId))
                return BadRequest($"The memberShipType don't exist.");

            customerDto.Id = customerInDb.Id; // Asignar id pasado por parámetro.
            // Se anulan los tipos porque el compilador los puede inferir.
            Mapper.Map(customerDto, customerInDb); // Copiar los datos de customerDto a customer.
            db.SaveChanges();

            return Ok(customerDto);
        }

        // Verbo Delete: /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = db.Customers.FirstOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            db.Customers.Remove(customerInDb);

            db.SaveChanges();

            return Ok("resource deleted");
        }
    }
}
