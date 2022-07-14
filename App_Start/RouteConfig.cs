using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Schoolmanagementn
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            /*routes.IgnoreRoute("{resource}.axd/{*pathInfo}");*/
            routes.IgnoreRoute("Roles/");
            /*routes.IgnoreRoute("Roles/Create/");*/
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                /*defaults: new { controller = "UserRegistrations", action = "Details", id = "SMU0001" }*/
                
            );
        }
    }
}
