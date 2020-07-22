using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhoneBookWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "People", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "GetStates",
                "{controller}/{action}",
                new { controller = "People", action = "GetStates" },
                 new[] { "PhoneBookWebApp.Controllerss" }
            );


            routes.MapRoute(
                "GetCities",
                "{controller}/{action}",
                new { controller = "People", action = "GetCities" },
                new[] { "PhoneBookWebApp.Controllerss" }
            );

        }
    }
}
