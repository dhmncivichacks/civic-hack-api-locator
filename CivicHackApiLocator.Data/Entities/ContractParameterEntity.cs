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
    /// Database implementation of ContractParameter
    /// </summary>
    public class ContractParameterEntity : ContractParameter
    {
        /// <summary>
        /// Gets or sets the ID of the entity
        /// </summary>
        public int Id { get; set; }

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
                Mapper.CreateMap<ContractParameterEntity, ContractParameter>();
            }
        }
    }
}
