﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Singular.Web.Admin.Views.Home
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    
    #line 1 "..\..\Views\Home\Index.cshtml"
    using System.Security.AccessControl;
    
    #line default
    #line hidden
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
    
    #line 2 "..\..\Views\Home\Index.cshtml"
    using Singular.Web.Admin.Controllers;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Home\Index.cshtml"
    using Singular.Web.Admin.Defaults;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Home\Index.cshtml"
    using Singular.Web.Common;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/Index.cshtml")]
    public partial class Index : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Index()
        {
        }
        public override void Execute()
        {





            
            #line 5 "..\..\Views\Home\Index.cshtml"
  
    Layout = null;


            
            #line default
            #line hidden
WriteLiteral("\n<!DOCTYPE html>\n\n<html>\n<head>\n    <meta name=\"viewport\" content=\"width=device-w" +
"idth\" />\n    <title>TBC title from object</title>\n    <script> window.ROOT_URL =" +
" \'");


            
            #line 15 "..\..\Views\Home\Index.cshtml"
                           Write(Url.Content("~/"));

            
            #line default
            #line hidden
WriteLiteral("\';</script>\n</head>\n    <body ng-app=\"Singular.Application\">\n        <header>\n   " +
"         <h1>Singular CMS</h1>\n        </header>\n        <section ng-view=\"\">\r\n " +
"           \r\n        </section>\n        ");


            
            #line 24 "..\..\Views\Home\Index.cshtml"
    Write(Html.EmbeddedInclude<NgViewController>(SingularAdminResources.ANGULAR_MIN_JS, IncludeType.JavaScript));

            
            #line default
            #line hidden
WriteLiteral("\n        ");


            
            #line 25 "..\..\Views\Home\Index.cshtml"
    Write(Html.EmbeddedInclude<NgViewController>(SingularAdminResources.ANGULAR_ROUTE_MIN_JS, IncludeType.JavaScript));

            
            #line default
            #line hidden
WriteLiteral("\n        ");


            
            #line 26 "..\..\Views\Home\Index.cshtml"
    Write(Html.EmbeddedInclude<NgViewController>(SingularAdminResources.SINGULAR_MIN_JS, IncludeType.JavaScript));

            
            #line default
            #line hidden
WriteLiteral("\n        \n    </body>\n</html>\n");


        }
    }
}
#pragma warning restore 1591