using System.ComponentModel.DataAnnotations;

namespace CivicHackApiLocator.Model
{
    /// <summary>
    /// A parameter needed to fulfill a contract
    /// </summary>
    public class ContractParameter
    {
        /// <summary>
        /// Gets or sets the ID of the entity
        /// </summary>
        public int Id { get; set; }

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
        /// Gets or sets a default value for the parameter
        /// </summary>
        public string DefaultValue { get; set; }
    }
}
