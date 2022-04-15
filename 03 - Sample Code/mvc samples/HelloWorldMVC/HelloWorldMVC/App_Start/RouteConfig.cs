using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelloWorldMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // new "Hello" route to support segment style URL
            routes.MapRoute(
                name: "Hello",                                                                                          // Route name is "Hello"
                url: "{controller}/{action}/{name}/{age}",                                                              // URL pattern with placeholders
                defaults: new { controller = "Hello", action = "SayHello1", name = "Gary", age = 35 }                   // defaults               
            );
           
        }
    }
}
