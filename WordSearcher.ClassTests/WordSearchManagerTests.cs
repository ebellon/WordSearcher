using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using WordSearcher.Interfaces;
using WordSearcher.UnitTests.Common;

namespace WordSearcher.UnitTests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class WordSearchManagerTests
    {
        [TestMethod]
        public void WordSearchManager_Test()
        {
            // Arrange
            int expectedFiles = 20;
            int expectedMatchesPerFile = 5;

            var filesystem = TestUtils.FileSystemBuilder(expectedFiles, "pattern", expectedMatchesPerFile);

            var loadDirs = new DirectoryLoader(filesystem);
            var searchWords = new WordSearcher(filesystem);

            var testee = new WordSearchManager(loadDirs, searchWords);

            // Act
            var numberOfFiles = testee.LoadDirectory("testDir");
            var topTen = testee.SearchMatches("pattern");

            // Assert
            Assert.AreEqual(expectedFiles, numberOfFiles);
            Assert.AreEqual(10, topTen.Count);
            topTen.ToList().ForEach((kvp) => Assert.AreEqual(expectedMatchesPerFile, kvp.Value));
        }

        [TestMethod]
        public void WordSearchManager_LoadDirectory_Test()
        {
            // Arrange
            var loadDirsMock = new Mock<ILoadDirectories>();
            var searchWordsMock = new Mock<ISearchWords>();

            var testee = new WordSearchManager(loadDirsMock.Object, searchWordsMock.Object);

            // Act
            testee.LoadDirectory("testDir");

            // Assert
            loadDirsMock.Verify(v => v.GetFiles("testDir"), Times.Once);
        }

        [TestMethod]
        public void WordSearchManager_SearchMatches_NoFiles_Test()
        {
            // Arrange
            var loadDirsMock = new Mock<DirectoryLoader>(TestUtils.FileSystemBuilder(0));
            var searchWordsMock = new Mock<ISearchWords>();

            var testee = new WordSearchManager(loadDirsMock.Object, searchWordsMock.Object);
            testee.LoadDirectory("testDir");

            // Act
            testee.SearchMatches("pattern");

            // Assert
            searchWordsMock.Verify(v => v.SearchWordsInFile("file", "pattern"), Times.Never);
        }

        [TestMethod]
        public void WordSearchManager_SearchMatches_MultipleFiles_Test()
        {
            // Arrange
            var loadDirsMock = new Mock<DirectoryLoader>(TestUtils.FileSystemBuilder(10));
            var searchWordsMock = new Mock<ISearchWords>();

            var testee = new WordSearchManager(loadDirsMock.Object, searchWordsMock.Object);
            testee.LoadDirectory("testDir");

            // Act
            testee.SearchMatches("pattern");

            // Assert
            searchWordsMock.Verify(v => v.SearchWordsInFile(It.IsAny<string>(), "pattern"), Times.Exactly(10));
        }
    }
}
