using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace CivicHackApiLocator.WebApi.Models
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
        /// Gets or sets the Id of the contract
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

        /// <summary>
        /// Automapper profile
        /// </summary>
        public class ContractProfile : Profile
        {
            /// <summary>
            /// Configures the automapper profile
            /// </summary>
            protected override void Configure()
            {
                CreateMap<Model.Contract, Contract>();
            }
        }
    }
}
