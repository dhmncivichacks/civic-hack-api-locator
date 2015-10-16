using System.Web.Http;
using CivicHackApiLocator.WebApi;
using Swashbuckle.Application;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CivicHackApiLocator.WebApi
{
    /// <summary>
    /// Swagger configuration
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Registers the swagger configuration
        /// </summary>
        public static void Register()
        {
            GlobalConfiguration.Configuration.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "CivicHackApiLocator.WebApi");
                c.DescribeAllEnumsAsStrings(true);
            }).EnableSwaggerUi();
        }
    }
}