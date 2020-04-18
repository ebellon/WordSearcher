using WordSearcher.Interfaces;

namespace WordSearcher
{
    internal class DirectoryLoader : ILoadDirectories
    {
        readonly IProvideFileSystem fileSystem;

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
