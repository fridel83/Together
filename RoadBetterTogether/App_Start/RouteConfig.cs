using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoadBetterTogether
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "ajouetrUser",
               url: "Ajouter/User",
               defaults: new { controller = "Home", action = "AjouterUser"}
           );

            routes.MapRoute(
                name: "login",
                url: "Login",
                defaults: new { controller = "Login", action = "Login" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
