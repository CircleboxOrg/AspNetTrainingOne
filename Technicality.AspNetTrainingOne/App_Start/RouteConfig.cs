using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Technicality.AspNetTrainingOne
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // we want the tenantAlias to be a "wildcard" so we need to hardcode the other controller routes

            routes.MapRoute(
                name: "Cities",
                url: "cities/{action}/{id}",
                defaults: new { controller = "Cities", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "KendoCity",
                url: "kendocity/{action}/{id}",
                defaults: new { controller = "KendoCity", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Tenant",
                url: "{tenantAlias}/{action}/{id}",
                defaults: new { controller = "Tenant", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index"}
            );

        }
    }
}
