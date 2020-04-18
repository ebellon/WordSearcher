using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordSearcher.Interfaces;

namespace WordSearcher
{
    internal class WordSearchManager : IManageWordSearch
    {
        private readonly ILoadDirectories directoriesLoader;
        private readonly ISearchWords wordSearcher;
        private List<string> filesToSearch = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="WordSearchManager"/> class.
        /// </summary>
        /// <param name="directoriesLoader">The directories loader.</param>
        /// <param name="wordSearcher">The word searcher.</param>
        public WordSearchManager(ILoadDirectories directoriesLoader, ISearchWords wordSearcher)
        {
            this.directoriesLoader = directoriesLoader;
            this.wordSearcher = wordSearcher;
        }

        /// <inheritdoc/>
        public int LoadDirectory(string path)
        {
            filesToSearch = this.directoriesLoader.GetFiles(path).ToList();
            return filesToSearch.Count;
        }

        /// <inheritdoc/>
        public IDictionary<string, int> SearchMatches(string pattern)
        {
            var matchesResult = new ConcurrentDictionary<string, int>();

            Parallel.ForEach(filesToSearch, (currentFile) =>
            {
                var matches = this.wordSearcher.SearchWordsInFile(currentFile, pattern);

                if (matches > 0)
                {
                    _ = matchesResult.TryAdd(currentFile, matches);
                }
            });

            return (from a in matchesResult
                          orderby a.Value descending
                          select a).Take(10).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
