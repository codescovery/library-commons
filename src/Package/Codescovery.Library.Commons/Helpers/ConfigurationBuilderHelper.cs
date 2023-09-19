using System.IO;
using System.Linq;
using Codescovery.Library.Commons.Entities.Directory;
using Codescovery.Library.Commons.Extensions;

namespace Codescovery.Library.Commons.Helpers
{
    public static class ConfigurationBuilderHelper
    {
        public const string DefaultConfigurationFileName = "appsettings.json";
        public const string DefaultConfigurationFileExtension = ".json";
        public const string DefaultConfigurationFileExtensionSeparator = ".";
        public const string DefaultConfigurationsProjectSubFolderName = "Configurations";
        public static readonly FolderPath DefaultBasePath = Directory.GetCurrentDirectory();
        public static FolderPath GetCurrentDirectoryBasePath(FolderPath? basePath =null, params string[]? paths)
        {
            var pathsList = paths ?? new string[] { };
            var persistedPaths = pathsList.Prepend(GetBasePath(basePath).Value);
            return Path.Combine(persistedPaths.ToArray());
        }
        public static FolderPath GetBasePath(FolderPath? basePath = null)
        {
            if (basePath==null) return DefaultBasePath;
            return basePath.Value.IsNullOrEmptyOrWhiteSpace() ? DefaultBasePath : basePath;
        }
}
}
