using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordSearcher.ClassTests.Common;

namespace WordSearcher.ClassTests
{
    [TestClass]
    public class LoadDirTests
    {
        [DataRow(0)]
        [DataRow(999)]
        [DataRow(100000)]
        [TestMethod]
        public void LoadDirTestNumberOfFiles(int expectedFiles)
        {
            //arrange
            var fileSystem = TestUtils.FileSystemBuilder(expectedFiles);
            var testee = new DirectoryLoader(fileSystem);

            //act
            var actualFiles = testee.GetFiles("testDir").Length;

            //assess
            Assert.AreEqual(expectedFiles, actualFiles);
        }
    }
}
