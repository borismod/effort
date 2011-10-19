﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFProviderWrapperToolkit;
using System.Data.Common;
using System.Data.Common.CommandTrees;

namespace MMDB.EntityFrameworkProvider.Components
{
    /// <summary>
    /// Implementation of <see cref="DbProviderServices"/> for MMMDBWrapperProvider.
    /// </summary>
    internal class MMDBWrapperProviderServices : DbProviderServicesBase
    {
        static MMDBWrapperProviderServices()
        {
            MMDBWrapperProviderServices.Instance = new MMDBWrapperProviderServices();
        }

        internal static MMDBWrapperProviderServices Instance { private set; get; }

        /// <summary>
        /// Prevents a default instance of the EFSampleProviderServices class from being created.
        /// </summary>
        private MMDBWrapperProviderServices()
        {
        }


        /// <summary>
        /// Gets the default name of the wrapped provider.
        /// </summary>
        /// <returns>
        /// Default name of the wrapped provider (to be used when
        /// provider is not specified in the connction string)
        /// </returns>
        protected override string DefaultWrappedProviderName
        {
            get { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Gets the provider invariant iname.
        /// </summary>
        /// <returns>Provider invariant name.</returns>
        protected override string ProviderInvariantName
        {
            get { return DatabaseAcceleratorProviderConfiguration.ProviderInvariantName; }
        }


        /// <summary>
        /// Creates the command definition wrapper.
        /// </summary>
        /// <param name="wrappedCommandDefinition">The wrapped command definition.</param>
        /// <param name="commandTree">The command tree.</param>
        /// <returns>
        /// The <see cref="DbCommandDefinitionWrapper"/> object.
        /// </returns>
        public override DbCommandDefinitionWrapper CreateCommandDefinitionWrapper(DbCommandDefinition wrappedCommandDefinition, DbCommandTree commandTree)
        {
            return new DbCommandDefinitionWrapper(
                wrappedCommandDefinition, 
                commandTree, 
                (cmd, def) => new MMDBWrapperCommand(cmd, def));
        }
    }
}