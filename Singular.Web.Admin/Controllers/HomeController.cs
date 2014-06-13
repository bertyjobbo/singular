using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Singular.Configuration;

namespace Singular.Web.Admin.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index - returns dashboard layout
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}