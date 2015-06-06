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
        Get,
        
        /// <summary>HTTP POST with url encoded body</summary>
        PostFormUrlEncoded,

        /// <summary>HTTP POST with JSON body</summary>
        PostJson
    }

    /// <summary>
    /// A contract defines the way data will be returned by an API
    /// </summary>
    public class Contract
    {
        /// <summary>
        /// Gets or sets the DB ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Describes the type of data returned by the API
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the schema that describes the format that data will be returned in
        /// </summary>
        [Required]
        public string JsonSchema { get; set; }

        /// <summary>
        /// Gets or sets the way the request should be formed
        /// </summary>
        public RequestMode RequestMode { get; set; }

        /// <summary>
        /// Gets or sets a list of parameters to the query
        /// </summary>
        public List<ContractParameter> Parameters { get; set; }
    }
}
