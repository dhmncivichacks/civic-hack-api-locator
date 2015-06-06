using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CivicHackApiLocator.Model;
using Moq;

namespace CivicHackApiLocator.Data
{
    /// <summary>
    /// A mock DbContext for the Civic Hack API Locator application
    /// </summary>
    public static class MockChalContext
    {
        /// <summary>
        /// Creates the mock context
        /// </summary>
        public static ChalContext Create()
        {
            var contracts = new List<Contract>
            {
                new Contract
                {
                    Description = "Returns Property Information",
                    JsonSchema = "TODO",
                    Parameters = new List<ContractParameter>
                    {
                        new ContractParameter
                        {
                            Name = "h",
                            Description = "House Number",
                            Required = true
                        },
                        new ContractParameter
                        {
                            Name = "s",
                            Description = "Street Name",
                            Required = true
                        }
                    },
                    RequestMode = RequestMode.Get
                },
                new Contract
                {
                    Description = "Returns Property Information",
                    JsonSchema = "TODO",
                    Parameters = new List<ContractParameter>
                    {
                        new ContractParameter
                        {
                            Name = "propertyId",
                            Description = "Property ID",
                            Required = true
                        }
                    }
                }
            };

            var locations = new List<ImplementationLocation>
            {
                new ImplementationLocation { ZipCode = "54911" },
                new ImplementationLocation { ZipCode = "54912" },
                new ImplementationLocation { ZipCode = "54913" },
                new ImplementationLocation { ZipCode = "54914" },
                new ImplementationLocation { ZipCode = "54915" },
                new ImplementationLocation { ZipCode = "54916" },
                new ImplementationLocation { ZipCode = "54919" }
            };

            var implementations = new List<Implementation>
            {
                new Implementation
                {
                    ApiUrl = "http://appletonapi.appspot.com/search?h={h}&s={s}",
                    Contract = contracts[0],
                    Locations = locations
                },
                new Implementation
                {
                    ApiUrl = "http://appletonapi.appspot.com/property/{propertyId}",
                    Contract = contracts[1],
                    Locations = locations
                }
            };

            var mockContext = new Mock<ChalContext>();

            mockContext.Setup(x => x.Contracts).Returns(CreateMockSet(contracts));
            mockContext.Setup(x => x.Implementations).Returns(CreateMockSet(implementations));

            return mockContext.Object;
        }

        /// <summary>
        /// Creates a mock DbSet
        /// </summary>
        private static DbSet<T> CreateMockSet<T>(IEnumerable<T> data) where T : class
        {
            var queryableData = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableData.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableData.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryableData.GetEnumerator());

            return mockSet.Object;
        }
    }
}
