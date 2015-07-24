using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using CivicHackApiLocator.Data;
using CivicHackApiLocator.Model;
using CivicHackApiLocator.WebApi.Models;

namespace CivicHackApiLocator.WebApi.Controllers
{
    /// <summary>
    /// Web API controller to query implementations
    /// </summary>
    public class ImplementationsController : ApiController
    {
        private readonly ChalContext _context;

        /// <summary>
        /// Initializes a new instance of the ImplementationsController class
        /// </summary>
        public ImplementationsController(ChalContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns implementations that are valid for the given zip code
        /// </summary>
        [Route("api/implementations/byzipcode/{zipCode}"), HttpGet]
        public IEnumerable<ImplementationDescription> ByZipCode(string zipCode)
        {
            foreach (var imp in _context.Implementations.Where(x => x.Locations.Any(y => y.ZipCode == zipCode)))
            {
                yield return new ImplementationDescription(imp);
            }
        }

        /// <summary>
        /// Returns implementations of the given contract
        /// </summary>
        [Route("api/implementations/bycontract/{contractName}"), HttpGet]
        public IEnumerable<ImplementationDescription> ByContract(string contractName)
        {
            foreach (var imp in _context.Implementations.Where(x => x.Contract.ContractName == contractName))
            {
                yield return new ImplementationDescription(imp);
            }
        }

        /// <summary>
        /// Gets the full description of the implementation
        /// </summary>
        [Route("api/implementations/{contractName}/{implementationName}"), HttpGet]
        public Implementation Implementations(string contractName, string implementationName)
        {
            return Mapper.Map<Implementation>(_context.Implementations.SingleOrDefault(x => x.Contract.ContractName == contractName && x.ImplementationName == implementationName));
        }
    }
}