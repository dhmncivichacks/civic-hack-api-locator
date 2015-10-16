using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CivicHackApiLocator.Data.Entities;
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
            var contracts = CreateContracts();
            var implementations = CreateImplementations(contracts);

            var mockContext = new Mock<ChalContext>();

            mockContext.Setup(x => x.Contracts).Returns(CreateMockSet(contracts));
            mockContext.Setup(x => x.Implementations).Returns(CreateMockSet(implementations));

            return mockContext.Object;
        }

        /// <summary>
        /// Creates mock contracts
        /// </summary>
        public static List<ContractEntity> CreateContracts()
        {
            return new List<ContractEntity>
            {
                new ContractEntity
                {
                    Id = 1,
                    ContractName = "upcoming-garbage-recycling-dates",
                    Description = "Returns upcoming dates for garbage and recycling collection",
                    ResponseJsonSchema = @"{
                        ""type"": ""array"",
                        ""items"": {
                            ""type"": ""object"",
                            ""properties"": {
                                ""collectionType"": {
                                    ""enum"": [
                                        ""trash"",
                                        ""recycling""
                                    ],
                                    ""type"": ""string""
                                },
                                ""collectionDate"": {
                                    ""format"": ""date"",
                                    ""type"": ""string""
                                }
                            }
                        }
                    }",
                    Parameters = new List<ContractParameterEntity>
                    {
                        new ContractParameterEntity
                        {
                            Name = "addr",
                            Description = "Address",
                            Location = ParameterLocation.Query,
                            Format = ParameterFormat.String,
                            Required = true
                        },
                        new ContractParameterEntity
                        {
                            Name = "startDate",
                            Description = "Start Date",
                            Location = ParameterLocation.Query,
                            Format = ParameterFormat.Date
                        },
                        new ContractParameterEntity
                        {
                            Name = "endDate",
                            Description = "End Date",
                            Location = ParameterLocation.Query,
                            Format = ParameterFormat.Date
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Creates mock implementations
        /// </summary>
        public static List<ImplementationEntity> CreateImplementations(List<ContractEntity> contracts)
        {
            return new List<ImplementationEntity>
            {
                new ImplementationEntity
                {
                    ApiUrl = "http://greenville-wi-api.azurewebsites.net/api/GarbageCollection",
                    HomepageUrl = "http://greenville-wi-api.azurewebsites.net",
                    ImplementationName = "greenville-wi-garbage",
                    Contract = contracts[0],
                    Locations = new List<ImplementationLocationEntity>
                    {
                        new ImplementationLocationEntity { ZipCode = "54942" }
                    }
                },
                new ImplementationEntity
                {
                    ApiUrl = "http://appletonapi.appspot.com/garbagecollection",
                    HomepageUrl = "http://appletonapi.appspot.com",
                    ImplementationName = "appleton-wi-garbage",
                    Contract = contracts[0],
                    Locations = new List<ImplementationLocationEntity>
                    {
                        new ImplementationLocationEntity { ZipCode = "54911" },
                        new ImplementationLocationEntity { ZipCode = "54912" },
                        new ImplementationLocationEntity { ZipCode = "54913" },
                        new ImplementationLocationEntity { ZipCode = "54914" },
                        new ImplementationLocationEntity { ZipCode = "54915" },
                        new ImplementationLocationEntity { ZipCode = "54919" }
                    }
                }
            };
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
