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
        public virtual Contract Contract { get; set; }

        /// <summary>
        /// The URL for the API.  If the requestMode is Get, the url should contain placeholders for all parameters.
        /// For example: http://www.test.com/{param1}?q={param2}
        /// </summary>
        [Required]
        public string ApiUrl { get; set; }

        /// <summary>
        /// Gets or sets the way the request should be formed
        /// </summary>
        public RequestMode RequestMode { get; set; }

        /// <summary>
        /// The locations covered by this implementation
        /// </summary>
        public virtual List<ImplementationLocation> Locations { get; set; }
    }
}
