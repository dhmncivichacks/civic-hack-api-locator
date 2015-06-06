using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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
        public ImplementationsController()
        {
            _context = MockChalContext.Create();
        }

        /// <summary>
        /// Returns implementations that are valid for the given zip code
        /// </summary>
        [Route("implementations/byzipcode/{id}")]
        public IEnumerable<Implementation> ByZipCode(string id)
        {
            return _context.Implementations.Where(x => x.Locations.Any(y => y.ZipCode == id));
        }

        /// <summary>
        /// Returns information about the implementation with the given ID
        /// </summary>
        public Implementation Get(int id)
        {
            return _context.Implementations.SingleOrDefault(x => x.Id == id);
        }
    }
}