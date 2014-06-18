using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Singular.Web.Admin.Defaults
{
    public static class SingularAdminResources
    {
        // main
        public const string ANGULAR_MIN_JS = "Singular.Web.Admin.Scripts.angular.min.js";
        public const string ANGULAR_ROUTE_MIN_JS = "Singular.Web.Admin.Scripts.angular-route.min.js";
        public const string SINGULAR_MIN_JS = "Singular.Web.Admin.Ng.singular.min.js";

        // controller
        public const string NAV_CONTROLLER_MIN_JS = "Singular.Web.Admin.Ng.controllers.partials.navController.min.js";
        public const string HOME_CONTROLLER_MIN_JS = "Singular.Web.Admin.Ng.controllers.homeController.min.js";
        public const string SYSTEM_CONTROLLER_MIN_JS = "Singular.Web.Admin.Ng.controllers.systemController.min.js";

        // directive
        public const string SG_VIEW_DIRECTIVE_MIN_JS = "Singular.Web.Admin.Ng.directives.sgView.min.js";
        
        // service
        public const string CONFIG_DATA_SERVICE_MIN_JS = "Singular.Web.Admin.Ng.services.configDataService.min.js";
    }
}