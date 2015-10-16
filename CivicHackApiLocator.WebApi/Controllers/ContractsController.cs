using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using CivicHackApiLocator.Data;
using CivicHackApiLocator.Model;

namespace CivicHackApiLocator.WebApi.Controllers
{
    /// <summary>
    /// Web API controller to query contracts
    /// </summary>
    public class ContractsController : ApiController
    {
        private readonly ChalContext context;

        /// <summary>
        /// Initializes a new instance of the ContractsController class
        /// </summary>
        public ContractsController(ChalContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets all available contracts
        /// </summary>
        public IEnumerable<Contract> Get()
        {
            return Mapper.Map<IEnumerable<Contract>>(this.context.Contracts);
        }
    }
}