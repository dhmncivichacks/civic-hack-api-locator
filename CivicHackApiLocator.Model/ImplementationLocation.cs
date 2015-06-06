using System.ComponentModel.DataAnnotations;

namespace CivicHackApiLocator.Model
{
    /// <summary>
    /// A location where the implementation is valid
    /// </summary>
    public class ImplementationLocation
    {
        /// <summary>
        /// Gets or sets the ID of the entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the zip code where the implementation is valid
        /// </summary>
        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the implementation
        /// </summary>
        public virtual Implementation Implementation { get; set; }
    }
}
