using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Handlers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace Singular.Web.Common
{
    /// <summary>
    /// Html extensions
    /// </summary>
    public static class HtmlExtensions
    {
        /// <summary>
        /// Embedded include
        /// </summary>
        /// <typeparam name="TInAssembly"></typeparam>
        /// <param name="html"></param>
        /// <param name="name"></param>
        /// <param name="includeType"></param>
        /// <returns></returns>
        public static MvcHtmlString EmbeddedInclude<TInAssembly>(this HtmlHelper html, string name,
            IncludeType includeType)
        {
            return embeddedInclude<TInAssembly>(html, name, includeType);
        }

        /// <summary>
        /// Embedded include
        /// </summary>
        /// <typeparam name="TInAssembly"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="html"></param>
        /// <param name="name"></param>
        /// <param name="includeType"></param>
        /// <returns></returns>
        public static MvcHtmlString EmbeddedInclude<TInAssembly,TModel>(this HtmlHelper<TModel> html, string name,
            IncludeType includeType)
        {
            return embeddedInclude<TInAssembly>(html, name, includeType);
        }

        private static readonly Page _page = new Page();

        /// <summary>
        /// Actual method
        /// </summary>
        /// <typeparam name="TInAssembly"></typeparam>
        /// <param name="html"></param>
        /// <param name="name"></param>
        /// <param name="includeType"></param>
        /// <returns></returns>
        private static MvcHtmlString embeddedInclude<TInAssembly>(HtmlHelper html, string name, IncludeType includeType)
        {
            var resourceUrl = _page.ClientScript.GetWebResourceUrl(typeof (TInAssembly), name);

            var outputStr = string.Empty;

            switch (includeType)
            {
                case IncludeType.JavaScript:
                {
                    outputStr = string.Format("<script src=\"{0}\"></script>", resourceUrl);
                    break;
                }
                case IncludeType.Stylesheet:
                {
                    outputStr = string.Format("<link rel=\"stylesheet\" href=\"{0}\" />", resourceUrl);
                    break;
                }
            }

            return MvcHtmlString.Create(outputStr);
        }
    }
}
