using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Singular.Web.Admin.Defaults
{
    public static class SingularAdminDefaults
    {
        public const string APP_ID = "959d33a7-c386-42db-b932-01e04be7a5e5";
        public static Guid AppId
        {
            get
            {
                if (_appId == Guid.Empty) _appId = new Guid(APP_ID);
                return _appId;
            }
        }
        private static Guid _appId;

        public const string APP_NAME = "Singular CMS - by developers, for developers";
    }
}