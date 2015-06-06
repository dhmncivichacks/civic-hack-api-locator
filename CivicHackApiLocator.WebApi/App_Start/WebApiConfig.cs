using System.Web.Http;

namespace CivicHackApiLocator.WebApi
{
    /// <summary>
    /// Web API configuration
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers Web API configuration
        /// </summary>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }
    }
}
