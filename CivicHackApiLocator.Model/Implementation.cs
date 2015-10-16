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
        /// Gets or sets the contract implemented by the API
        /// </summary>
        public virtual Contract Contract { get; set; }

        /// <summary>
        /// Gets or sets the name of the implementation
        /// </summary>
        public string ImplementationName { get; set; }

        /// <summary>
        /// Gets or sets the URL of the homepage of the implementation
        /// </summary>
        public string HomepageUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL for the API.  If the contract contains "Path" parameters, they must be included using braces in the URL
        /// For example: http://www.test.com/widget/{id}
        /// </summary>
        [Required]
        public string ApiUrl { get; set; }

        /// <summary>
        /// Gets or sets the locations covered by this implementation
        /// </summary>
        public List<ImplementationLocation> Locations { get; set; }
    }
}
