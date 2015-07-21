using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CivicHackApiLocator.Model;

namespace CivicHackApiLocator.Data.Entities
{
    /// <summary>
    /// Database implementation of Contract
    /// </summary>
    public class ContractEntity : Contract
    {
        /// <summary>
        /// Gets or sets the DB ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a list of parameters to the contract
        /// </summary>
        public new virtual List<ContractParameterEntity> Parameters { get; set; }

        /// <summary>
        /// Automapper profile
        /// </summary>
        public class Profile : AutoMapper.Profile
        {
            /// <summary>
            /// Configures automapping
            /// </summary>
            protected override void Configure()
            {
                Mapper.CreateMap<ContractEntity, Contract>();
            }
        }
    }
}
