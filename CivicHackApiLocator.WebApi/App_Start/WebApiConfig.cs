using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using Microsoft.ApplicationInsights;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

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

            // Use camel case for JSON serialization
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
            jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);

            // Capture exceptions for Application Insights:
            config.Filters.Add(new AiExceptionFilterAttribute());
        }

        /// <summary>
        /// Application Insights Exception Handler
        /// </summary>
        private class AiExceptionFilterAttribute : ExceptionFilterAttribute
        {
            /// <summary>
            /// Handles a raised exception
            /// </summary>
            public override void OnException(HttpActionExecutedContext actionExecutedContext)
            {
                if (actionExecutedContext != null && actionExecutedContext.Exception != null)
                {
                    var ai = new TelemetryClient();
                    ai.TrackException(actionExecutedContext.Exception);
                }

                base.OnException(actionExecutedContext);
            }
        }
    }
}
