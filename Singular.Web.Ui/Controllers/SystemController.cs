using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Singular.Web.Ui.Controllers
{
    public class SystemController:Controller
    {
        public ActionResult Error()
        {
            return Content("An error has occured. This is the default catchall page.", "text/plain");
        }
    }
}