using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")] // needed for Moq testing
namespace WordSearcher.Interfaces
{
    internal interface IProvideFileSystem
    {
        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <param name="path">The path.</param>
        string[] GetFiles(string path);


        /// <summary>
        /// Reads all text.
        /// </summary>
        /// <param name="path">The path.</param>
        string ReadAllText(string path);
    }
}
