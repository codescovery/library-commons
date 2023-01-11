using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codescovery.Library.Commons.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codescovery.Library.Commons.Test.Context
{
    internal class DependencyInjectionContext
    {
        public IServiceCollection Services { get; }
        public IConfiguration Configuration { get; }

        public DependencyInjectionContext()
        {
            Services = new ServiceCollection();
            Configuration = new ConfigurationBuilder()
                .SetBasePath(ConfigurationBuilderHelper.GetCurrentDirectoryBasePath(null, ConfigurationBuilderHelper.DefaultConfigurationsProjectSubFolderName))
                .AddJsonFile(ConfigurationBuilderHelper.DefaultConfigurationFileName)
                .Build();
        }
        public IServiceScopeFactory? GetServiceScopeFactory()
        {
            var serviceScopeFactory = Services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            return serviceScopeFactory;
        }
    }
}
