namespace WordSearcher.Interfaces
{
    interface IManageWordSearch
    {
        /// <summary>
        /// Loads the directory.
        /// </summary>
        /// <param name="path">The directory path.</param>
        void LoadDirectory(string path);

        /// <summary>
        /// Searches the matches.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        void SearchMatches(string pattern);
    }
}
