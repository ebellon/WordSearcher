using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordSearcher.ClassTests.Common;

namespace WordSearcher.ClassTests
{
    [TestClass]
    public class WordSearchTests
    {
        [DataRow("testWord", 2)]
        [DataRow("ABCDEFG", 5)]
        [DataRow("WXYZ22", 20)]
        [TestMethod]
        public void WordSearchTest(string pattern, int expectedMatches)
        {
            //arrange
            var fileSystem = TestUtils.FileSystemBuilder(1, pattern, expectedMatches);
            var testee = new WordSearcher(fileSystem);

            //act
            var actualMatches = testee.SearchWordsInFile("testFile", pattern);

            //assess
            Assert.AreEqual(expectedMatches, actualMatches);
        }
    }
}
