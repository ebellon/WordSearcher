using System.Runtime.CompilerServices;
using WordSearcher.Interfaces;

namespace WordSearcher
{
    internal class DirectoryLoader : ILoadDirectories
    {
        readonly IProvideFileSystem fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryLoader"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        public DirectoryLoader(IProvideFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        /// <inheritdoc/>
        public string[] GetFiles(string path)
        {
            return this.fileSystem.GetFiles(path);
        }
    }
}
