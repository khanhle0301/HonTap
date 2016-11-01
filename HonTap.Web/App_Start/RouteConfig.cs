using System.Web.Mvc;
using System.Web.Routing;

namespace HonTap.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "Post Search",
             url: "tim-kiem.html",
             defaults: new { controller = "Post", action = "Search", tagId = UrlParameter.Optional },
             namespaces: new string[] { "HonTap.Web.Controllers" }
         );


            routes.MapRoute(
              name: "Post Tag",
              url: "tag/{tagId}.html",
              defaults: new { controller = "Post", action = "Tag", tagId = UrlParameter.Optional },
              namespaces: new string[] { "HonTap.Web.Controllers" }
          );

            routes.MapRoute(
               name: "Post Category",
               url: "{alias}.html",
               defaults: new { controller = "Post", action = "Category", alias = UrlParameter.Optional },
               namespaces: new string[] { "HonTap.Web.Controllers" }
           );

            routes.MapRoute(
              name: "Post Detail",
              url: "{catealias}/{alias}-{id}.html",
              defaults: new { controller = "Post", action = "Detail", id = UrlParameter.Optional },
              namespaces: new string[] { "HonTap.Web.Controllers" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "HonTap.Web.Controllers" }
            );
        }
    }
}