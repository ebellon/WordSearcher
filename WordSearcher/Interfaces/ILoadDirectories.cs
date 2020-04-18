namespace WordSearcher.Interfaces
{
    internal interface ILoadDirectories
    {
        /// <summary>
        /// Gets the files of the given directory.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <returns>File list.</returns>
       string[] GetFiles(string path);
    }
}
