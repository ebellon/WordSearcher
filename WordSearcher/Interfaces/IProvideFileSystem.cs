namespace WordSearcher.Interfaces
{
    internal interface IProvideFileSystem
    {
        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        string[] GetFiles(string path);
    }
}
