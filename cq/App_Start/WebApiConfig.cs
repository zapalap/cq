using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace cq
{
    public static class WebApiConfig
    {
        public static HttpConfiguration BuildConfig()
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            return config;
        }
    }
}
