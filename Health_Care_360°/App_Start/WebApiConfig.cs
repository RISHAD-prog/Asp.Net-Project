using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Services.Protocols;

namespace Health_Care_360_
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
           
            config.Routes.MapHttpRoute(
               name: "route1",
               routeTemplate: "api/{controller}/{name}",
               defaults: new {name = @"^[a-zA-Z]" }
           );

            config.Routes.MapHttpRoute(
              name: "route2",
              routeTemplate: "api/{controller}/{email}",
              defaults: new { email = @"^[a-zA-Z0-9@.]" }
          );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.EnableCors();

        }
    }
}
