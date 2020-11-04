using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Models.IdentityModels;

namespace Vidly.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext db;

        public NewRentalsController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose(); // Limpia dbContext de la memoria.
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental == null)
                return BadRequest("No customer and movie.");

            if (newRental.MovieIds?.Count == 0)
                return BadRequest("No MovieIds have been given.");

            var customer = db.Customers.SingleOrDefault( // Leer el cliente.
                c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not valid.");

            // Cargar varias películas con contains equivalente a IN(1,2,3)
            var movies = db.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more MoviesIds are invalid.");

            if (movies.Any(m => m.NumberAvailable <= 0))
                return BadRequest("One or more movies are not available.");

            var todayDate = DateTime.Now; // Obtiene la fecha actual.

            // Crear todos los registros.
            foreach (var movie in movies)
            {
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = todayDate
                };
                // Guardar en memoria.
                db.Rentals.Add(rental);
                movie.NumberAvailable = movie.NumberAvailable - 1;//Decrementar en uno el número de peliculas.
            }
            // Guardar en la base de datos.
            db.SaveChanges();

            return Ok(newRental); // Crear recurso con estado 201.
        }
    }
}
