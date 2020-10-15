﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public ActionResult Index()
        {
            var moviesData = GetMovies();
            var movies = new List<Movie>();
            movies = moviesData.ToList();
            if (movies.Count == 0)
            {
                return View();
            }
            else
            {
                return View(movies);
            }
        }

        
        [Route("Movies/Details/{id}")]
        public ActionResult MovieDetails(int id)
        {
            if (id < 25)
            {
                var moviesData = GetMovies();
                var movie = moviesData.FirstOrDefault(m => m.Id == id);
                return View(movie);
            }
            else
            {
                return HttpNotFound();
            }
        }

        private static IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie { Id = 1, Name = "Spiderman" },
                new Movie { Id = 2, Name = "Men in black" },
                new Movie { Id = 3, Name = "Fantastic Four" },
                new Movie { Id = 4, Name = "Pulp Fiction" },
                new Movie { Id = 5, Name = "The incredibles" },
                new Movie { Id = 6, Name = "Godzila" },
                new Movie { Id = 7, Name = "Jurassic World" },
                new Movie { Id = 8, Name = "Fantastic Animals" },
                new Movie { Id = 9, Name = "John Wick" },
                new Movie { Id = 10, Name = "Bumblebee" },
                new Movie { Id = 11, Name = "Mad Max" },
                new Movie { Id = 12, Name = "It" },
                new Movie { Id = 13, Name = "Scooby-Doo" },
                new Movie { Id = 14, Name = "Extraction" },
                new Movie { Id = 15, Name = "Wonder" },
                new Movie { Id = 16, Name = "Charlie and the Chocolate Factory" },
                new Movie { Id = 17, Name = "The Dark Night" },
                new Movie { Id = 18, Name = "Ransom" },
                new Movie { Id = 19, Name = "Project Power" },
                new Movie { Id = 20, Name = "Flu" },
                new Movie { Id = 21, Name = "Bird Box" },
                new Movie { Id = 22, Name = "Harry Potter" },
                new Movie { Id = 23, Name = "World War Z" },
                new Movie { Id = 24, Name = "Pets United" },
                new Movie { Id = 25, Name = "The Mask" }
            };
        }

        // Get Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!"}; // Instancia el modelo.
            var customers = new List<Customer>()
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
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel); // Llama a la vista de nombre Random.
        }

        public ActionResult Edit(int movieId) // Acción con parámetro declarado.
        {
            return Content("id=" + movieId);
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"year: {year}, month: {month}");
        }

        [Route("movies/release/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content($"year: {year}, month: {month}");
        }
    }
}