using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using WordSearcher.Interfaces;

namespace WordSearcher.Common
{
    [ExcludeFromCodeCoverage]
    internal static class Bootstrapper
    {
        /// <summary>
        /// Setups the Dependency injection.
        /// </summary>
        /// <returns>ServiceProvider</returns>
        public static ServiceProvider Setup()
        {
            return new ServiceCollection()
             .AddSingleton<ILoadDirectories, DirectoryLoader>()
             .AddSingleton<IProvideFileSystem, PhysicalFileSystem>()
             .AddSingleton<ISearchWords, WordSearcher>()
             .AddSingleton<IManageWordSearch, WordSearchManager>()
             .BuildServiceProvider();
        }
    }
}
