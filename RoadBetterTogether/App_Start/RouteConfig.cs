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
               name: "ajouterUser",
               url: "Ajouter/User",
               defaults: new { controller = "Login", action = "AjouterUser"}
           );

            routes.MapRoute(
               name: "ajouterUserInfo",
               url: "Ajouter/UserInfo",
               defaults: new { controller = "Login", action = "AjouterUserInfo" }
           );

            routes.MapRoute(
                name: "login",
                url: "Login",
                defaults: new { controller = "Login", action = "Login" }
                );

            routes.MapRoute(
                name: "Ajouterhome",
                 url: "{controller}/{action}",
                 defaults: new { controller = "Login", action = "AjouterHome" }
                 );

            routes.MapRoute(
                name: "Ajouterwork",
                url: "{controller}/{action}",
                defaults: new { controller = "Login", action = "AjouterHome" }
                );

            routes.MapRoute(
               name: "Ajoutercar",
               url: "{controller}/{action}",
               defaults: new { controller = "Login", action = "AjouterCar" }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
