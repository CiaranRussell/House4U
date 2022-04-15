using System.Web.Mvc;
using System.Web.Routing;

namespace StockOrder
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Stock", action = "Order", id = UrlParameter.Optional }
            );
        }
    }
}
