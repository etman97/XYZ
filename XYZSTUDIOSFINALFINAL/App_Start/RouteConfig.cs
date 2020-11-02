using System.Web.Mvc;
using System.Web.Routing;

namespace XYZSTUDIOSFINALFINAL
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
                    new[] { "XYZSTUDIOSFINALFINAL.Controllers" }
            );

            routes.MapRoute("Account", "Account{action}/{id}", new { Controller = "Account", Action = "Index", id = UrlParameter.Optional }, new[] { "XYZSTUDIOSFINALFINAL" });

            routes.MapRoute(
                "Pages",
                "{controller}/{action}/{id}",
                new { controller = "Pages", action = "Index", id = UrlParameter.Optional },
                new[] { "XYZSTUDIOSFINALFINAL.Controllers" }
            );

            routes.MapRoute(
                "Admin",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "Pages", action = "Index", id = UrlParameter.Optional },
                new[] { "XYZSTUDIOSFINALFINAL.Areas.Admin.Controllers" }
            );

            routes.MapRoute(
             "User",
             "Admin/{controller}/{action}/{id}",
             new { Controller = "User", action = "Index", id = UrlParameter.Optional },
             new[] { "XYZSTUDIOSFINALFINAL.Areas.Admin.Controllers" }
         );
        }
    }
}
