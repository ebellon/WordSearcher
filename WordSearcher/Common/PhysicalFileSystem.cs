using System.IO;
using WordSearcher.Interfaces;

namespace WordSearcher
{
    internal class PhysicalFileSystem : IProvideFileSystem
    {
        /// <inheritdoc/>
        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }
    }
}
