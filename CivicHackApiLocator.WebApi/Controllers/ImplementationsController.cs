using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using CivicHackApiLocator.Data;
using CivicHackApiLocator.Model;
using CivicHackApiLocator.WebApi.Models;
using Geocoding.Google;

namespace CivicHackApiLocator.WebApi.Controllers
{
    /// <summary>
    /// Web API controller to query implementations
    /// </summary>
    public class ImplementationsController : ApiController
    {
        private readonly ChalContext context;

        /// <summary>
        /// Initializes a new instance of the ImplementationsController class
        /// </summary>
        public ImplementationsController(ChalContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns implementations that are valid for the given zip code
        /// </summary>
        [Route("api/implementations/byzipcode/{zipCode}"), HttpGet]
        public IEnumerable<ImplementationDescription> ByZipCode(string zipCode)
        {
            foreach (var imp in this.context.Implementations.Where(x => x.Locations.Any(y => y.ZipCode == zipCode)))
            {
                yield return new ImplementationDescription(imp);
            }
        }

        /// <summary>
        /// Returns implementations that are valid for the given address
        /// DEPRECATED - REMOVE AFTER CHRIS MERGES PULL REQUEST
        /// </summary>
        [Route("api/implementations/byaddress/{address}"), HttpGet]
        public IEnumerable<ImplementationDescription> ByAddress(string address)
        {
            var geocoder = new GoogleGeocoder();
            var geocodeResponse = geocoder.Geocode(address).FirstOrDefault();

            if (geocodeResponse != null)
            {
                var zipComponent = geocodeResponse.Components.First(x => x.Types.Contains(GoogleAddressType.PostalCode));

                if (zipComponent != null)
                {
                    var zip = zipComponent.LongName;

                    if (zip.Length > 5)
                        zip = zip.Substring(0, 5);

                    return this.ByZipCode(zip);
                }
            }

            return new List<ImplementationDescription>();
        }

        /// <summary>
        /// Returns implementations that are valid for the given address
        /// </summary>
        [Route("api/implementations"), HttpGet]
        public IEnumerable<ImplementationDescription> Search(string addr = null, string zipCode = null)
        {
            if (!string.IsNullOrEmpty(addr))
            {
                var geocoder = new GoogleGeocoder();
                var geocodeResponse = geocoder.Geocode(addr).FirstOrDefault();

                if (geocodeResponse != null)
                {
                    var zipComponent = geocodeResponse.Components.First(x => x.Types.Contains(GoogleAddressType.PostalCode));

                    if (zipComponent != null)
                    {
                        var zip = zipComponent.LongName;

                        if (zip.Length > 5)
                            zip = zip.Substring(0, 5);

                        return this.ByZipCode(zip);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(zipCode))
            {
                return this.ByZipCode(zipCode);
            }

            return new List<ImplementationDescription>();
        }

        /// <summary>
        /// Returns implementations of the given contract
        /// </summary>
        [Route("api/implementations/bycontract/{contractName}"), HttpGet]
        public IEnumerable<ImplementationDescription> ByContract(string contractName)
        {
            foreach (var imp in this.context.Implementations.Where(x => x.Contract.ContractName == contractName))
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
            return Mapper.Map<Implementation>(this.context.Implementations.SingleOrDefault(x => x.Contract.ContractName == contractName && x.ImplementationName == implementationName));
        }
    }
}