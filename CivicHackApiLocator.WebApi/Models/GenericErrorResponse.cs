using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CivicHackApiLocator.WebApi.Models
{
    /// <summary>
    /// A generic format for returning errors
    /// </summary>
    public class GenericErrorResponse
    {
        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        public string Message { get; set; }
    }
}