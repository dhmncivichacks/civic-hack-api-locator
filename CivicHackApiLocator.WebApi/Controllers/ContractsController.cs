using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CivicHackApiLocator.Data;
using CivicHackApiLocator.Model;

namespace CivicHackApiLocator.WebApi.Controllers
{
    /// <summary>
    /// Web API controller to query contracts
    /// </summary>
    public class ContractsController : ApiController
    {
        private readonly ChalContext _context;

        /// <summary>
        /// Initializes a new instance of the ContractsController class
        /// </summary>
        public ContractsController()
        {
            _context = MockChalContext.Create();
        }

        /// <summary>
        /// Gets all available contracts
        /// </summary>
        public IEnumerable<Contract> Get()
        {
            return _context.Contracts.ToList();
        }
    }
}