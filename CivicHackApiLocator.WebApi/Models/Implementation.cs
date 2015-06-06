using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CivicHackApiLocator.WebApi.Models
{
    /// <summary>
    /// Implements a Contract for a number of locations
    /// </summary>
    public class Implementation
    {
        /// <summary>
        /// The contract implemented by the API
        /// </summary>
        public Contract Contract { get; set; }

        /// <summary>
        /// The URL for the API.  If the contract RequestMode is Get, the url should contain placeholders for all parameters.
        /// For example: http://www.test.com/{param1}?q={param2}
        /// </summary>
        [Required]
        public string ApiUrl { get; set; }

        /// <summary>
        /// Gets or sets the zip codes this implementation supports
        /// </summary>
        public List<string> ZipCodes { get; set; }

        /// <summary>
        /// Gets or sets the way the request should be formed
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public RequestMode RequestMode { get; set; }

        /// <summary>
        /// Automapper profile
        /// </summary>
        public class ImplementationProfile : Profile
        {
            /// <summary>
            /// Configures the automapper profile
            /// </summary>
            protected override void Configure()
            {
                CreateMap<Model.Implementation, Implementation>()
                    .ForMember(x => x.ZipCodes, x => x.MapFrom(y => y.Locations.Select(z => z.ZipCode).ToList()));
            }
        }
    }
}
