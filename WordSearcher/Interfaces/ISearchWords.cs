namespace WordSearcher.Interfaces
{
    interface ISearchWords
    {
        /// <summary>
        /// Searches the words in file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>Number of matches.</returns>
        int SearchWordsInFile(string filePath, string pattern);
    }
}
