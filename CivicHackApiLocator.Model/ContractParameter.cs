using System.ComponentModel.DataAnnotations;

namespace CivicHackApiLocator.Model
{
    /// <summary>
    /// Formats as defined in http://swagger.io/specification/#dataTypeFormat
    /// </summary>
    public enum ParameterFormat
    {
        /// <summary>32-bit integer</summary>
        Int32,

        /// <summary>64-bit integer</summary>
        Int64,

        /// <summary>32-bit floating point number</summary>
        Float,

        /// <summary>64-bit floating point number</summary>
        Double,

        /// <summary>A string</summary>
        String,

        /// <summary>Base-64 encoded byte array</summary>
        Byte,

        /// <summary>true or false</summary>
        Boolean,

        /// <summary>Date only in YYYY-MM-DD format</summary>
        Date,

        /// <summary>DateTime in ISO 8601 format</summary>
        DateTime,

        /// <summary>A password (only purpose is to indicate this should be masked in a GUI)</summary>
        Password
    }

    /// <summary>
    /// The location of the parameter
    /// </summary>
    public enum ParameterLocation
    {
        /// <summary>Parameter is in the query string</summary>
        Query,

        /// <summary>Parameter is sent as an HTTP header</summary>
        Header,

        /// <summary>Parameter is sent as a path component.  Must be specified using braces in the implementation URL!</summary>
        Path
    }

    /// <summary>
    /// A parameter needed to fulfill a contract
    /// </summary>
    public class ContractParameter
    {
        /// <summary>
        /// Gets or sets the name of the parameter
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description of what the parameter is used for
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the parameter is required
        /// </summary>
        [Required]
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets the format of the parameter
        /// </summary>
        public ParameterFormat Format { get; set; }

        /// <summary>
        /// Gets or sets the location of the parameter
        /// </summary>
        public ParameterLocation Location { get; set; }
    }
}
