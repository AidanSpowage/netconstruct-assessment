using System.Web.Mvc;
using System.Web.Routing;

namespace NetC.JuniorDeveloperExam.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "BlogPost", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Blog",
                url: "blog/{id}",
                defaults: new { controller = "BlogPost", action = "Blog" });
        }
    }
}
