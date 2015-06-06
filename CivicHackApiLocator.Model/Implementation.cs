using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CivicHackApiLocator.Model
{
    /// <summary>
    /// Implements a Contract for a number of locations
    /// </summary>
    public class Implementation
    {
        /// <summary>
        /// Gets or sets the ID of the entity
        /// </summary>
        public int Id { get; set; }

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
        /// The locations covered by this implementation
        /// </summary>
        public List<ImplementationLocation> Locations { get; set; }
    }
}
