using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CivicHackApiLocator.Model;

namespace CivicHackApiLocator.WebApi.Models
{
    /// <summary>
    /// Information about implementations
    /// </summary>
    public class ImplementationDescription
    {
        /// <summary>
        /// Initializes a new instance of the ImplementationDescription class
        /// </summary>
        public ImplementationDescription(Implementation imp)
        {
            this.ContractName = imp.Contract.ContractName;
            this.ContractDescription = imp.Contract.Description;
            this.HomepageUrl = imp.HomepageUrl;
            this.ImplementationName = imp.ImplementationName;
            this.ImplementationApiUrl = imp.ApiUrl;
        }

        /// <summary>
        /// Gets or sets the name of the contract
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// Gets or sets the description of the contract
        /// </summary>
        public string ContractDescription { get; set; }

        /// <summary>
        /// Gets or sets the name of the implementation
        /// </summary>
        public string ImplementationName { get; set; }

        /// <summary>
        /// Gets or sets the homepage URL of the implementation
        /// </summary>
        public string HomepageUrl { get; set; }

        /// <summary>
        /// Gets or sets the API URL of the implementation
        /// </summary>
        public string ImplementationApiUrl { get; set; }

        /// <summary>
        /// Gets the base URL from the ImplementationApiUrl
        /// </summary>
        public string ImplementationBaseUrl
        {
            get { return new Uri(this.ImplementationApiUrl).GetLeftPart(UriPartial.Authority); }
        }

        /// <summary>
        /// Gets the path from the ImplementationApiUrl
        /// </summary>
        public string ImplementationPath
        {
            get { return new Uri(this.ImplementationApiUrl).PathAndQuery; }
        }
    }
}