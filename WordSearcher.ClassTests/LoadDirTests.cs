using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using WordSearcher.UnitTests.Common;

namespace WordSearcher.UnitTests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class LoadDirTests
    {
        [DataRow(0)]
        [DataRow(999)]
        [DataRow(100000)]
        [TestMethod]
        public void LoadDirTestNumberOfFiles(int expectedFiles)
        {
            // Arrange
            var fileSystem = TestUtils.FileSystemBuilder(expectedFiles);
            var testee = new DirectoryLoader(fileSystem);

            // Act
            var actualFiles = testee.GetFiles("testDir").Length;

            // Assess
            Assert.AreEqual(expectedFiles, actualFiles);
        }
    }
}
