using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace ArtBase.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            var constraints = new { httpMethod = new HttpMethodConstraint(HttpMethod.Options) };
            config.EnableCors(cors);
            config.MapHttpAttributeRoutes();
            config.Routes.IgnoreRoute("OPTIONS", "*pathInfo", constraints);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
