using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings; // Obtiene el objeto de ajustes del objeto de configuración http.
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // Resuelve las peticiones JSON con CamelCase.
            settings.Formatting = Formatting.Indented; // Devuelve el objeto indentado correctamente.

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
