using System.Collections.Generic;

namespace WordSearcher.Interfaces
{
    interface IManageWordSearch
    {
        /// <summary>
        /// Loads the directory.
        /// </summary>
        /// <param name="path">The directory path.</param>
        int LoadDirectory(string path);

        /// <summary>
        /// Searches the matches.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        IDictionary<string, int> SearchMatches(string pattern);
    }
}
