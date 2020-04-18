using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordSearcher.ClassTests.Common;

namespace WordSearcher.ClassTests
{
    [TestClass]
    public class WordSearchTests
    {
        [TestMethod]
        public void WordSearchTest()
        {
            int expectedMatches = 2;

            //arrange
            var fileSystem = TestUtils.FileSystemBuilder(1, "testWord", expectedMatches);
            var testee = new WordSearcher(fileSystem);

            //act
            var actualMatches = testee.SearchWordsInFile("testFile", "testWord");

            //assess
            Assert.AreEqual(expectedMatches, actualMatches);
        }
    }
}
