using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.IdentityModels;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        // Return the form to the client.
        public ActionResult New()
        {
            return View();
        }
    }
}
