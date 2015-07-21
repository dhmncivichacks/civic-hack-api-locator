using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using CivicHackApiLocator.Data;
using CivicHackApiLocator.Model;

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
        [Route("api/implementations/byzipcode/{id}")]
        public IEnumerable<Implementation> ByZipCode(string id)
        {
            return
                Mapper.Map<IEnumerable<Implementation>>(
                    _context.Implementations.Where(x => x.Locations.Any(y => y.ZipCode == id)));
        }

        /// <summary>
        /// Returns implementations of the given contract
        /// </summary>
        [Route("api/implementations/bycontract/{id}")]
        public IEnumerable<Implementation> ByContract(string id)
        {
            var test = Mapper.Map<IEnumerable<Implementation>>(_context.Implementations.Where(x => x.Contract.ContractName == id));
            return test;
        }
    }
}