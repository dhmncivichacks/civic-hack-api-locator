using System.Web;
using System.Web.Http;

namespace CivicHackApiLocator.WebApi
{
    /// <summary>
    /// Web API application root
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
