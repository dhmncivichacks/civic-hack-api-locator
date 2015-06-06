using System.Web;
using System.Web.Http;
using AutoMapper;
using CivicHackApiLocator.Data;
using CivicHackApiLocator.WebApi.Models;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

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

            Mapper.Initialize(x =>
            {
                x.AddProfile<Contract.ContractProfile>();
                x.AddProfile<ContractParameter.ContractParameterProfile>();
                x.AddProfile<Implementation.ImplementationProfile>();
            });


            // Set up SimpleInjector...
            var container = new Container();
            container.RegisterWebApiRequest(MockChalContext.Create);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
