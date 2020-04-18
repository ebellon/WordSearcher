using Microsoft.Extensions.DependencyInjection;
using WordSearcher.Interfaces;

namespace WordSearcher.Common
{
    internal static class ServicesProvider
    {
        /// <summary>
        /// Setups the Dependency injection.
        /// </summary>
        /// <returns>ServiceProvider</returns>
        public static ServiceProvider SetupDI()
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
