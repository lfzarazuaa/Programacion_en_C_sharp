﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Models.IdentityModels;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext db;

        public MoviesController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose(); // Limpia dbContext de la memoria.
        }

        // Verbo GET: /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = db.Movies.Include(m => m.Genre)
                .Where(m => m.NumberAvailable>0);

            if (!String.IsNullOrWhiteSpace(query)) // Filtrado de movies por nombre.
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }

            var moviesDto = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(moviesDto);
        }

        // Verbo GET: /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = db.Movies.FirstOrDefault(m => m.Id.Equals(id));

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie)); // Respuesta Código 200 y objeto.
        }

        // Verbo POST: /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest($"The arguments are invalid: {movieDto}");

            if (!db.Genres.Any(g => g.Id == movieDto.GenreId))
                return BadRequest($"The genre don't exist.");

            var movie = db.Movies.Add(Mapper.Map<MovieDto, Movie>(movieDto));
            movie.NumberAvailable = movie.NumberInStock;
            movie.DateAdded = DateTime.UtcNow; // Registrar la fecha de añadido.
            db.SaveChanges();

            movieDto.Id = movie.Id; // Asignar el Id desde la db.
            movieDto.NumberAvailable = movie.NumberInStock;
            movieDto.DateAdded = movie.DateAdded;// Regresar la fecha de añadido.
            return Created(new Uri($"{Request.RequestUri}/{movieDto.Id}"), movieDto); // Crear recurso con estado 201 y pasar un objeto como respuesta.
        }

        // Verbo PUT: /api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            var movieInDb = db.Movies.FirstOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest($"The arguments are invalid, needed: {movieDto}");

            if (!db.Genres.Any(g => g.Id == movieDto.GenreId))
                return BadRequest($"The genre don't exist.");

            movieDto.Id = movieInDb.Id; // Asignar id pasado por parámetro.
            movieDto.DateAdded = movieInDb.DateAdded;// Asignar la fecha de añadido.
            // Se anulan los tipos porque el compilador los puede inferir.
            Mapper.Map(movieDto, movieInDb); // Copiar los datos de movieDto a movie.
            db.SaveChanges();

            return Ok(movieDto);
        }

        // Verbo Delete: /api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = db.Movies.FirstOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            db.Movies.Remove(movieInDb);

            db.SaveChanges();

            return Ok("resource deleted");
        }
    }
}
