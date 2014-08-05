using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Singular.Web.Admin.Defaults
{
    // TODO: USE MINIFIED VERSIONS OF JS IN FINAL PRODUCT
    public static class SingularAdminResources
    {
        // css
        public const string SG_MIN_CSS = "Singular.Web.Admin.Content.Css.sg.min.css";
        public const string SG_CONTROLS_CSS_MIN = "Singular.Web.Admin.SgControls.sg-controls.min.css";
        public const string NORMALIZE_CSS = "Singular.Web.Admin.Content.normalize.css";

        // main
        public const string ANGULAR_MIN_JS = "Singular.Web.Admin.Scripts.angular.min.js";
        public const string ANGULAR_ROUTE_MIN_JS = "Singular.Web.Admin.Scripts.angular-route.min.js";
        public const string SINGULAR_MIN_JS = "Singular.Web.Admin.Ng.singular.js";

        // sg controls
        public const string SG_ROUTE_MIN_JS = "Singular.Web.Admin.SgControls.sgRoute.js";
        public const string SG_ELEMENTS_MIN_JS = "Singular.Web.Admin.SgControls.sgElements.js";

        // controller
        public const string HEADER_CONTROLLER_MIN_JS = "Singular.Web.Admin.Ng.controllers.partials.headerController.js";
        public const string HOME_CONTROLLER_MIN_JS = "Singular.Web.Admin.Ng.controllers.homeController.js";
        public const string SYSTEM_CONTROLLER_MIN_JS = "Singular.Web.Admin.Ng.controllers.systemController.js";
        public const string CONFIGURATION_CONTROLLER_MIN_JS = "Singular.Web.Admin.Ng.controllers.configurationController.js";

        // service
        public const string CONFIG_DATA_SERVICE_MIN_JS = "Singular.Web.Admin.Ng.services.configDataService.js";
        
    }
}