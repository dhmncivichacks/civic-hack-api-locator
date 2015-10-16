using System.Data.Entity;

namespace CivicHackApiLocator.Data
{
    /// <summary>
    /// Context initializer for the ChalContext
    /// </summary>
    public class ChalContextInitializer : CreateDatabaseIfNotExists<ChalContext>
    {
        /// <summary>
        /// Seeds the database with data
        /// </summary>
        protected override void Seed(ChalContext context)
        {
            var contracts = MockChalContext.CreateContracts();
            context.Contracts.AddRange(contracts);
            context.Implementations.AddRange(MockChalContext.CreateImplementations(contracts));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
