using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Singular.Web.Admin.Controllers
{
    public class NgViewController : Controller
    {
        // GET: AngularViews
        public ActionResult GetView(string folder, string file)
        {
            return View("~/Views/NgView/" + folder + "/" + file + ".cshtml");
        }
    }
}