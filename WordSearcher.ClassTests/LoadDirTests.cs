using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WordSearcher.Interfaces;

namespace WordSearcher.ClassTests
{
    [TestClass]
    public class LoadDirTests
    {

        [TestMethod]
        public void LoadDirTestNoFiles()
        {
            //arrange
            int expectedfiles = 0;
            var fileSystem = this.FileSystemBuilder(expectedfiles);

            var testee = new DirectoryLoader(fileSystem);

            //act
            var actualFiles = testee.GetFiles("testDir0").Length;

            //assess
            Assert.AreEqual(expectedfiles, actualFiles);
        }

        [TestMethod]
        public void LoadDirTest999Files()
        {
            //arrange
            int expectedfiles = 999;
            var fileSystem = this.FileSystemBuilder(expectedfiles);

            var testee = new DirectoryLoader(fileSystem);

            //act
            var actualFiles = testee.GetFiles("testDir999").Length;

            //assess
            Assert.AreEqual(expectedfiles, actualFiles);
        }

        [TestMethod]
        public void LoadDirTest100000Files()
        {
            //arrange
            int expectedfiles = 100000;
            var fileSystem = this.FileSystemBuilder(expectedfiles);

            var testee = new DirectoryLoader(fileSystem);

            //act
            var actualFiles = testee.GetFiles("testDir100000").Length;

            //assess
            Assert.AreEqual(expectedfiles, actualFiles);
        }

        private IProvideFileSystem FileSystemBuilder(int numberOfFiles)
        {
            var fileSystem = new Mock<IProvideFileSystem>();
            fileSystem.Setup(fs => fs.GetFiles(It.IsAny<string>())).Returns(() => FileGenerator(numberOfFiles));

            return fileSystem.Object;
        }

        private static string[] FileGenerator(int numberOfFiles)
        {
            var result = new List<string>();
            for (int i = 0; i < numberOfFiles; i++)
            {
                result.Add($"file.{i}");
            }

            return result.ToArray();
        }
    }
}
