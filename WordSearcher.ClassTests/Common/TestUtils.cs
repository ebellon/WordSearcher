using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using WordSearcher.Interfaces;

namespace WordSearcher.UnitTests.Common
{
    internal static class TestUtils
    {
        private const int textFileLenght = 10000;

        public static IProvideFileSystem FileSystemBuilder(int numberOfFiles)
        {
            return FileSystemBuilder(numberOfFiles, string.Empty, 0);
        }

        public static IProvideFileSystem FileSystemBuilder(int numberOfFiles, string pattern, int numberOfPatterns)
        {
            var fileSystem = new Mock<IProvideFileSystem>();
            fileSystem.Setup(fs => fs.GetFiles(It.IsAny<string>())).Returns(() => FileGenerator(numberOfFiles));
            fileSystem.Setup(fs => fs.ReadAllText(It.IsAny<string>())).Returns(() => GenerateStringWithPattern(pattern, numberOfPatterns));

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

        private static string GenerateStringWithPattern(string pattern, int numberOfPatterns)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var randomString = new string(Enumerable.Repeat(chars, textFileLenght)
              .Select(s => s[RandomNumberGenerator.GetInt32(s.Length)]).ToArray());

            for (int i = 0; i < numberOfPatterns; i++)
            {
                var randomPosition = RandomNumberGenerator.GetInt32(textFileLenght);
                randomString = randomString.Insert(randomPosition, pattern);
            }

            return randomString;
        }
    }
}
