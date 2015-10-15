using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CivicHackApiLocator.WebApi.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Starts up our angular app!
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
    }
}