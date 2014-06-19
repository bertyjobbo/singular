using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
using Singular.Web.Admin.Defaults;

[assembly: AssemblyTitle("Singular.Web.Admin")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("Singular.Web.Admin")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("4eba756c-c3bc-49cf-b0e2-417e7dbd7327")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// RESOURCES

// angular
[assembly: System.Web.UI.WebResource(SingularAdminResources.ANGULAR_MIN_JS, "application/x-javascript")]
[assembly: System.Web.UI.WebResource(SingularAdminResources.ANGULAR_ROUTE_MIN_JS, "application/x-javascript")]

// singular
[assembly: System.Web.UI.WebResource(SingularAdminResources.SINGULAR_MIN_JS, "application/x-javascript")]

// controllers
[assembly: System.Web.UI.WebResource(SingularAdminResources.NAV_CONTROLLER_MIN_JS, "application/x-javascript")]
[assembly: System.Web.UI.WebResource(SingularAdminResources.HOME_CONTROLLER_MIN_JS, "application/x-javascript")]
[assembly: System.Web.UI.WebResource(SingularAdminResources.SYSTEM_CONTROLLER_MIN_JS, "application/x-javascript")]
[assembly: System.Web.UI.WebResource(SingularAdminResources.CONFIGURATION_CONTROLLER_MIN_JS, "application/x-javascript")]

// directives
[assembly: System.Web.UI.WebResource(SingularAdminResources.SG_VIEW_DIRECTIVE_MIN_JS, "application/x-javascript")]

// services
[assembly: System.Web.UI.WebResource(SingularAdminResources.CONFIG_DATA_SERVICE_MIN_JS, "application/x-javascript")]

