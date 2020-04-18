using Microsoft.Extensions.DependencyInjection;
using System;
using WordSearcher.Common;
using WordSearcher.Interfaces;

namespace WordSearcher
{
    public class Program 
    {
        // TODO: make it a program argument
        const string dirToLoad = @"c:\tmp";

        static void Main(string[] args)
        {
            Console.WriteLine("Word Searcher\r");
            Console.WriteLine("------------------------\n");

            // Setup dependency injection
            using (var serviceProvider = ServicesProvider.SetupDI())
            {
                // Load directory
                var directoryLoader = serviceProvider.GetRequiredService<ILoadDirectories>();
                var filesInDir = directoryLoader.GetFiles(dirToLoad);

                Console.WriteLine($"There are {filesInDir.Length} in {dirToLoad}");
                Console.WriteLine("Press Q to exit");
                Console.WriteLine();

                // Search Logic here
                do
                {
                    Console.Write("search>");

                } while (Console.ReadLine() != "Q");
            }
        }
    }
}
