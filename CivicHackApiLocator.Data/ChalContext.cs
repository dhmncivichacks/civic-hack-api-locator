using System.Data.Entity;
using CivicHackApiLocator.Data.Entities;

namespace CivicHackApiLocator.Data
{
    /// <summary>
    /// Entity Framework context for the Civic Hack API Locator application
    /// </summary>
    public class ChalContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the ChalContext class
        /// </summary>
        public ChalContext()
        {
            Database.SetInitializer(new ChalContextInitializer());
        }

        /// <summary>
        /// Gets or sets the contracts DbSet
        /// </summary>
        public virtual DbSet<ContractEntity> Contracts { get; set; }

        /// <summary>
        /// Gets or sets the contract parameters DbSet
        /// </summary>
        public virtual DbSet<ContractParameterEntity> ContractParameters { get; set; }

        /// <summary>
        /// Gets or sets the implementations DbSet
        /// </summary>
        public virtual DbSet<ImplementationEntity> Implementations { get; set; }

        /// <summary>
        /// Gets or sets the implementation Locations DbSet
        /// </summary>
        public virtual DbSet<ImplementationLocationEntity> ImplementationLocations { get; set; }
    }
}
