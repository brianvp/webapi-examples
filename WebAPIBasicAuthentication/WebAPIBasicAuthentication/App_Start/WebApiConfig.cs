using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace WebApiBasicAuthentication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            config.MapHttpAttributeRoutes();

            //doesn't seem to fix the issue
            //config.EnableCors();

            // For custom search actions in the Search controller, tried to 
            // initially set the routing here, but ran into issues with two actions having the same parameter list
            // I found it was easier to use Attribute Routing in the SearchController itself...
            /*
             config.Routes.MapHttpRoute("PartNumberSearch", "api/search/PartNumbers", new { controller = "Search", Action = "GetPartNumberSearch" });
             config.Routes.MapHttpRoute("ModelSearch", "api/search/Models", new { controller = "Search", Action = "GetModelSearch" });
            */

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            

        }
    }
}
