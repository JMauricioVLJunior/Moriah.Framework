using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc
{
    public static class ExtensionsMethods
    {
        public static string ActionName(this HtmlHelper file)
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();

        }

        public static string ControllerName(this HtmlHelper file)
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        }
    }
}
