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
    /// Database implementation of Implementation
    /// </summary>
    public class ImplementationEntity : Implementation
    {
        /// <summary>
        /// Gets or sets the ID of the entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the locations covered by this implementation
        /// </summary>
        public new virtual List<ImplementationLocationEntity> Locations { get; set; }

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
                Mapper.CreateMap<ImplementationEntity, Implementation>();
            }
        }
    }
}
