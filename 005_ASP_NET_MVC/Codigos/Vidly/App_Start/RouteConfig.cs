﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(); // Activar el uso de Attribute Routing.

            routes.MapRoute( // Creación de ruta personalizada.
                name: "MoviesByReleaseDate",
                url: "movies/released/{year}/{month}",
                defaults: new { controller = "Movies", action = "ByReleaseDate"},
                constraints: new { year = @"\d{4}", month = @"\d{2}" } // Expresión regular a cumplir 4 dígitos para el año y 2 dígitos para el mes.
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
