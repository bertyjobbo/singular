using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySingularApplication.Defaults
{
    public static class MySingularDefaults
    {
        public const string APP_ID = "e68c3a3b-8c33-4ee9-b4c6-1c4c91010fa8";
        public static Guid AppId {
            get
            {
                if(_appId== Guid.Empty) _appId=new Guid(APP_ID);
                return _appId;
            }
        }

        private static Guid _appId;
    }
}