using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PharmaCore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "PharmaCore.Controllers" } // Namespace کنترلرهای Root
            );

            //            routes.MapRoute(
            //    name: "Admin",
            //    url: "Admin/{controller}/{action}/{id}",
            //    defaults: new { action = "Index", id = UrlParameter.Optional },
            //     namespaces: new[] { "CoreSuite.Areas.Admin.Controllers" } // Namespace کنترلرهای Area
            //);
        }
    }
}
