﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Singular.Web.Admin.Views.NgView.partials
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/NgView/partials/_nav.cshtml")]
    public partial class nav : System.Web.Mvc.WebViewPage<dynamic>
    {
        public nav()
        {
        }
        public override void Execute()
        {
WriteLiteral("<nav ng-controller=\"navController\">\r\n    <ul ng-repeat=\"item in navItems\">\r\n     " +
"   <li>{{ item.Title }}</li>\r\n    </ul>\r\n</nav>\r\n");


        }
    }
}
#pragma warning restore 1591
