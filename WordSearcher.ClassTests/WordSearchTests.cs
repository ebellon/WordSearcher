using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using WordSearcher.UnitTests.Common;

namespace WordSearcher.UnitTests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class WordSearchTests
    {
        [DataRow("testWord", 2)]
        [DataRow("ABCDEFG", 5)]
        [DataRow("WXYZ22", 20)]
        [TestMethod]
        public void WordSearchTest(string pattern, int expectedMatches)
        {
            // Arrange
            var fileSystem = TestUtils.FileSystemBuilder(1, pattern, expectedMatches);
            var testee = new WordSearcher(fileSystem);

            // Act
            var actualMatches = testee.SearchWordsInFile("testFile", pattern);

            // Assert
            Assert.AreEqual(expectedMatches, actualMatches);
        }
    }
}
