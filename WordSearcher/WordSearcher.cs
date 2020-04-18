using System.Text.RegularExpressions;
using WordSearcher.Interfaces;

namespace WordSearcher
{
    internal class WordSearcher : ISearchWords
    {
        readonly IProvideFileSystem fileSystem;

        public WordSearcher(IProvideFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public int SearchWordsInFile(string filePath, string pattern)
        {
            var text = this.fileSystem.ReadAllText(filePath);
            return new Regex(pattern).Matches(text).Count;
        }
    }
}
