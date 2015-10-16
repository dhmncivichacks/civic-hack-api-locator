using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CivicHackApiLocator.Model
{
    /// <summary>
    /// Defines the types of requests that can be used to access the contract
    /// </summary>
    public enum RequestMode
    {
        /// <summary>HTTP GET</summary>
        Get
    }

    /// <summary>
    /// A contract defines the way data will be returned by an API
    /// </summary>
    public class Contract
    {   
        /// <summary>
        /// Gets or sets the publicly visible name of the contract
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// Gets or sets a description of the type of data returned by the API
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the schema that describes the format that data will be returned in
        /// </summary>
        [Required]
        public string ResponseJsonSchema { get; set; }

        /// <summary>
        /// Gets or sets the way the request should be formed
        /// </summary>
        public RequestMode RequestMode { get; set; }

        /// <summary>
        /// Gets or sets a list of parameters to the contract
        /// </summary>
        public List<ContractParameter> Parameters { get; set; }
    }
}
