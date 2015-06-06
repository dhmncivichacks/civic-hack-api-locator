using System.Data.Entity;
using CivicHackApiLocator.Model;
#pragma warning disable 1591

namespace CivicHackApiLocator.Data
{
    /// <summary>
    /// Entity Framework context for the Civic Hack API Locator application
    /// </summary>
    public class ChalContext : DbContext
    {
        public virtual DbSet<Contract> Contracts { get; set; }

        public virtual DbSet<ContractParameter> ContractParameters { get; set; }

        public virtual DbSet<Implementation> Implementations { get; set; }

        public virtual DbSet<ImplementationLocation> ImplementationLocations { get; set; }
    }
}
