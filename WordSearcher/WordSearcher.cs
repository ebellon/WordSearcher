using System.Text.RegularExpressions;
using WordSearcher.Interfaces;

namespace WordSearcher
{
    internal class WordSearcher : ISearchWords
    {
        readonly IProvideFileSystem fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordSearcher"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        public WordSearcher(IProvideFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        /// <inheritdoc/>
        public int SearchWordsInFile(string filePath, string pattern)
        {
            var text = this.fileSystem.ReadAllText(filePath);
            return new Regex(pattern).Matches(text).Count;
        }
    }
}
