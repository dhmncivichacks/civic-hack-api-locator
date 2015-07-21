using System.Data.Entity;
using CivicHackApiLocator.Data.Entities;


#pragma warning disable 1591

namespace CivicHackApiLocator.Data
{
    /// <summary>
    /// Entity Framework context for the Civic Hack API Locator application
    /// </summary>
    public class ChalContext : DbContext
    {
        public ChalContext()
        {
            Database.SetInitializer(new ChalContextInitializer());
        }

        public virtual DbSet<ContractEntity> Contracts { get; set; }

        public virtual DbSet<ContractParameterEntity> ContractParameters { get; set; }

        public virtual DbSet<ImplementationEntity> Implementations { get; set; }

        public virtual DbSet<ImplementationLocationEntity> ImplementationLocations { get; set; }
    }
}
