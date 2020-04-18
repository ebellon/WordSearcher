using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void LoadDirectory(string path)
        {
            filesToSearch = this.directoriesLoader.GetFiles(path).ToList();
            Console.WriteLine($"There are {filesToSearch.Count} in {path}");
        }

        /// <inheritdoc/>
        public void SearchMatches(string pattern)
        {
            var matchesResult = new ConcurrentDictionary<string, int>();

            var stopWatch = Stopwatch.StartNew();
            Parallel.ForEach(filesToSearch, (currentFile) =>
            {
                var matches = this.wordSearcher.SearchWordsInFile(currentFile, pattern);

                if (matches > 0)
                {
                    _ = matchesResult.TryAdd(currentFile, matches);
                }
            });
            stopWatch.Stop();

            Console.WriteLine($"Search in {filesToSearch.Count} files took {stopWatch.ElapsedMilliseconds} ms"); 

            var topTen = (from a in matchesResult
                          orderby a.Value descending
                          select a).Take(10);

            topTen.ToList().ForEach((kvp) => Console.WriteLine($"file {kvp.Key} : {kvp.Value} ocurrences"));

        }
    }
}
