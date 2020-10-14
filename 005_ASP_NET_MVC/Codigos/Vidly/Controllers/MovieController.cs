﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // Get Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!"}; // Instancia el modelo.
            return View(movie); // Llama a la vista de nombre Random.
        }

    }
}